using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {
	public ScoreManager scoreManager;
	public GameObject animatorSkeleton;
	public VidaControle vidaControle;
	public SkinnedMeshRenderer meshRenderer;

	void Start () {
		this.scoreManager = GetComponentInParent<ContainerMonstro>().scoreManager;
		this.meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
	}

	void OnDestroy(){
	//	GritoDeMorte();
		scoreManager.pontuacao++;
	}
	
	public void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag.Equals("Crianca"))
			GolpeiaCrianca();

		if(other.gameObject.tag.Equals("Magia"))
		{
			GetComponent<Skeleton>().meshRenderer.enabled = false;
			Destroy(this.gameObject,0.9f);
			GritoDeMorte();
			GetComponent<CapsuleCollider>().enabled = false;
		}
	}
	void OnParticleCollision(GameObject other)
	{
		Destroy(this.gameObject,0.9f);
		GetComponent<Skeleton>().meshRenderer.enabled = false;
		GritoDeMorte();
		GetComponent<CapsuleCollider>().enabled = false;
	}

	public void Ataque()
	{
		GameObject crianca = GetComponentInParent<ContainerMonstro>().crianca;
		Vector3 posicaoSkeleton = GetComponent<Transform>().position;
		crianca.GetComponent<CriancaControle>().LevaHit(posicaoSkeleton);
		
	}	

	private void GolpeiaCrianca()
	{
		GameObject crianca = GetComponentInParent<ContainerMonstro>().crianca;
		transform.LookAt(crianca.transform);
		GetComponent<Animator>().Play("Ataque");
	}

	private void GritoDeMorte()
	{
		AudioClip somMorte = 
		GetComponentInParent<ContainerMonstro>()
			.audioInimigoModel.somMorte;

		AudioSource som = GetComponent<AudioSource>();

		som.clip = somMorte;
		som.Play();

	}
}
