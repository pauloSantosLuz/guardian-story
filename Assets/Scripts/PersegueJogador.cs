using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class PersegueJogador : MonoBehaviour {
	public GameObject crianca;
	public NavMeshAgent navMesh;
	private int distancia;
	void Start () {
		this.crianca = GetComponentInParent<ContainerMonstro>().crianca;
		this.navMesh = GetComponent<NavMeshAgent>();
		this.navMesh.destination = this.transform.position;

		int dificuldade = PlayerPrefs.GetInt("dificuldade");

		switch(dificuldade)
		{
			case 1: distancia = 15; break;
			case 2: distancia = 20; break;
			case 3: distancia = 25; break;
			case 4: distancia = 30; break; 

		}

	}
	
	void Update () {
		if(navMesh.destination == this.transform.position)
		{
			if(Vector3.Distance(crianca.transform.position, this.transform.position) < distancia)
			{
				GetComponent<Animator>().Play("Anda");
				navMesh.destination = crianca.transform.position;	

			}
		}else{
			navMesh.destination = crianca.transform.position;	
		}

	}
}
