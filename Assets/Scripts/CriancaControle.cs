using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriancaControle : MonoBehaviour {
	public VidaControle vidaControle;
	public AudioCriancaModel audioCriancaModel;

	public GameObject painelFimJogo;
	public MusicasAmbienteModel musicasAmbienteModel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		VerificaMorte();

		if(Input.GetKeyDown("b"))
			GetComponent<Animator>().Play("CaiDeBunda");
		if(Input.GetKeyDown("c"))
			GetComponent<Animator>().Play("Morre");
	}

	public void LevaHit(Vector3 posicaoAgressor)
	{
		Vector3 posicaoRelativaInimigo = transform.InverseTransformPoint(posicaoAgressor);
		if(posicaoRelativaInimigo.x < 0f)
		{
			GetComponent<Animator>().Play("DanoLateralEsquerdo");
		}
		if(posicaoRelativaInimigo.x > 0f)
		{
			GetComponent<Animator>().Play("DanoLateralDireito");
		}
		if(posicaoRelativaInimigo.x == 0f)
		{
			GetComponent<Animator>().Play("CaiDeBunda");
		}
		this.vidaControle.PerdeVida();
		EfeitoSonoroLevaDano();
	}

	public void VerificaMorte()
	{
		if(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Morre"))
			return;
		int qtdVida = GetComponent<CriancaControle>().vidaControle.GetNumVida();
		if(qtdVida == 0)
		{
			GetComponent<CriancaControle>().Morre();
			EfeitoSonoroMorte();
		}
	}

	public void Morre()
	{
		StopAllCoroutines();
		GetComponent<Animator>().Play("Morre");
	}

	public void OnMorte()
	{
		Time.timeScale = 0f;

	 	Cursor.SetCursor(null, new Vector2(32,32),  CursorMode.Auto);

		GetComponent<CriancaControle>().painelFimJogo.SetActive(true);
		GetComponent<CriancaControle>().musicasAmbienteModel.TocaMusicaFinal();
	}

	public void EfeitoSonoroCorrida()
	{
		AudioSource som = GetComponent<AudioSource>();
		som.loop = true;
		AudioClip somPasso = GetComponent<CriancaControle>().audioCriancaModel.somPasso;
		if(som.clip != somPasso)
		{
			som.volume = 0.15f;
			som.clip = somPasso; 
			som.Play();
		}

	}

	public void EfeitoSonoroLevaDano()
	{
		AudioSource som = GetComponent<AudioSource>();
		som.loop = false;
		som.volume = 1f;
		AudioClip somDanoRecebido = GetComponent<CriancaControle>().audioCriancaModel.somDanoRecebido;
		som.clip = somDanoRecebido; 
		som.PlayDelayed(0.3f);
	}

	public void EfeitoSonoroMorte()
	{
		AudioSource som = GetComponent<AudioSource>();
		som.loop = false;
		som.volume = 1f;
		AudioClip somMorte = GetComponent<CriancaControle>().audioCriancaModel.somMorte;
		som.clip = somMorte; 
		som.PlayDelayed(0.5f);
	}
}
