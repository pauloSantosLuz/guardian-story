using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancaMagia : MonoBehaviour {
	public bool podeCastar = false;
	private float cdMagiaFogo = 0f;
	private float cdMagiaGelo = 0f;
	private float cdMagiaTerra = 0f;
	private float cdMagiaExplosao = 0f;

	public GameObject magiaTerra;
	public GameObject magiaFogo;
	public GameObject magiaGelo;
	public GameObject crianca;

	public Ray raio;
	public RaycastHit ponto;
	public Camera cam;
	public Vector3 pontoFrente;

	public Animator animatorKid;
	public GameObject explosao;
	public GameObject explosaoRaio;

	public Transform origemPlayer;
	public Transform player;
	public ManaControle manaControle;
	public AnimationClip[] animacoesAtaque = new AnimationClip[7];

	public AudioMagiaModel audioMagiaModel;

	public CoolDownControle coolDownControle;

	private Vector3 alvo;

	private Animator animatorPlayer;
	// Use this for initialization
	void Start () {
		this.animatorPlayer = player.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		AtualizaCd();

		AtualizaMira();

		if(Input.GetKeyDown("1"))
		{
			if(!magiaDisponivel(1) || cdMagiaFogo > 0f)
				return;

			PreparaMagia("LancaMagiaFogo");
			
		}

		if(Input.GetKeyDown("2"))
		{
			if(!magiaDisponivel(2) || cdMagiaGelo > 0f)
				return;

			PreparaMagia("LancaMagiaGelo");
		}
		if(Input.GetKeyDown("3"))
		{
			if(!magiaDisponivel(3) || cdMagiaTerra > 0f)
				return;

			PreparaMagia("LancaMagiaTerra");
		}
		if(Input.GetKeyDown("4"))
		{
			if(!magiaDisponivel(4) || cdMagiaExplosao > 0f)
				return;

			PreparaMagia("LancaMagiaExplosao");
		}
	}

	public void Corrida()
	{
		animatorKid.Play("Corrida");
	}

	public IEnumerator VoaAlvo(Vector3 alvo)
	{
		player.SetParent(null);
		player.LookAt(alvo);
		while(Vector3.Distance(player.position,alvo) > 1f)
		{
			player.position = Vector3.MoveTowards(player.position, alvo, 2f);
			yield return null;
		}
	}

	public IEnumerator Explode(Vector3 alvo)
	{
		yield return new WaitUntil(() => Vector3.Distance(player.position,alvo) <= 1f);
		
		var instancia = Instantiate(explosaoRaio,player.position,player.rotation);
		Destroy(instancia,1.8f);
		StopAllCoroutines();		
		StartCoroutine(RetornaPlayer(alvo));
	}

	public IEnumerator RetornaPlayer(Vector3 alvo)
	{
		yield return new WaitForSeconds(0.5f);

		player.LookAt(origemPlayer);

		while(Vector3.Distance(player.position,origemPlayer.position) > 1f)
		{
			player.position = Vector3.MoveTowards(player.position, origemPlayer.position, 2f);
			yield return null;
		}
		player.rotation = origemPlayer.rotation;
		player.SetParent(origemPlayer.transform);

	}

	public bool magiaDisponivel(int mana)
	{
		int manaDisponivel = manaControle.ManaDisponivel();

		if(manaDisponivel >= mana)
			return true;
		return false; 
	}

	private IEnumerator LancaMagiaFogo()
	{
		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(() => podeCastar);

		EfeitoSonoroMagia(audioMagiaModel.audioMagiaFogo,0f);

		var instancia = Instantiate(magiaFogo,transform.position,transform.rotation);
		instancia.GetComponent<Rigidbody>().velocity = instancia.transform.forward * 25;
		manaControle.GastaMana(1);		
		this.cdMagiaFogo = 1.5f;
		podeCastar = false;
		player.transform.localRotation = Quaternion.identity;
	}

	private IEnumerator LancaMagiaGelo()
	{
		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(() => podeCastar);

		EfeitoSonoroMagia(audioMagiaModel.audioMagiaGelo,0f);

		var instancia = Instantiate(magiaGelo,transform.position,transform.rotation);
		Destroy(instancia,1.5f);
		manaControle.GastaMana(2);
		this.cdMagiaGelo = 5f;
		podeCastar = false;
		player.transform.localRotation = Quaternion.identity;
	}
	private IEnumerator LancaMagiaTerra()
	{
		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(() => podeCastar);

		EfeitoSonoroMagia(audioMagiaModel.audioMagiaTerra,0f);
		animatorKid.Play("DeJoelho");
		Vector3 adicao = crianca.transform.forward;
		Quaternion rotacao = crianca.transform.rotation;
		var instancia = Instantiate(magiaTerra,crianca.transform.position  + adicao * 2.5f,rotacao);
		Destroy(instancia,5f);

		Invoke("Corrida",3f);
		manaControle.GastaMana(3);
		this.cdMagiaTerra = 10f;
		podeCastar = false;

	}

	private IEnumerator LancaMagiaExplosao()
	{
		yield return new WaitForSeconds(0.1f);
		yield return new WaitUntil(() => podeCastar);

		EfeitoSonoroMagia(audioMagiaModel.audioMagiaExplosao,0f);

		Vector3 alvo = ponto.point;
	 	    
		StopAllCoroutines();		
			
		StartCoroutine(VoaAlvo(alvo));
		StartCoroutine(Explode(alvo));

		manaControle.GastaMana(4);
		this.cdMagiaExplosao = 20f;
		podeCastar = false;

	}

	private void AtualizaMira()
	{
		raio = cam.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(raio,out ponto))
		{
			transform.LookAt(ponto.point);
		}
		else
		{
			//pontoFrente = cam.transform.position + raio.direction*100;
		}

	}

	private void AtualizaCd()
	{
		cdMagiaFogo -= Time.deltaTime;
		cdMagiaGelo -= Time.deltaTime;
		cdMagiaTerra -= Time.deltaTime;
		cdMagiaExplosao -= Time.deltaTime;

		coolDownControle.AtualizaCdFogo(cdMagiaFogo);
		coolDownControle.AtualizaCdGelo(cdMagiaGelo);
		coolDownControle.AtualizaCdTerra(cdMagiaTerra);
		coolDownControle.AtualizaCdExplosao(cdMagiaExplosao);

	}

	private void PreparaMagia(string magia)
	{
		if(!magia.Equals("LancaMagiaTerra"))
			player.transform.LookAt(ponto.point);
		int index = Random.Range(0,7);
		animatorPlayer.Play(animacoesAtaque[index].name);
		StopAllCoroutines();
		StartCoroutine(magia);

	}
	private void EfeitoSonoroMagia(AudioClip som, float delay)
	{
		Debug.Log(som.name);
		AudioSource audioSourcePlayer = this.player.gameObject.GetComponent<AudioSource>();
		audioSourcePlayer.clip = som;

		if(audioSourcePlayer.clip.name.Equals("Spell_03"))
			audioSourcePlayer.time = 4f;
		audioSourcePlayer.time = 0f;
		audioSourcePlayer.PlayDelayed(delay);

	}
}
