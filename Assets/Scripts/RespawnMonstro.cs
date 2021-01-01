using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMonstro : MonoBehaviour {

	public GameObject monstro;
	public GameObject respawnMonstro;
	public GameObject containerMonstro;
	private int onda = 1;
	private float countTime = 0;

	private	List<GameObject> listaRespawnMonstro = new List<GameObject>();

	void Start () {
		PegaRespawnPoint();
	}
	
	void Update () {
		countTime += Time.deltaTime;
		if(containerMonstro.transform.childCount == 0)
		{
			if(countTime > 2f)
			{
				InvocaMonstros();
				countTime = 0f;
			}
		}
	}

	public void InvocaMonstros()
	{
		for(int i = 0; i < 5 * onda; i++)
		{
			int respawnIndice = Random.Range(0, listaRespawnMonstro.Count);

			Vector3 posicao = listaRespawnMonstro[respawnIndice].transform.position;
			Quaternion rotacao = listaRespawnMonstro[respawnIndice].transform.rotation;

			var instancia = Instantiate(monstro,posicao,rotacao);
			instancia.transform.parent = containerMonstro.transform;

		}
		onda++;
	}

	public void PegaRespawnPoint()
	{
		Transform[] todasCriancas = respawnMonstro.GetComponentsInChildren<Transform>();
		foreach (Transform crianca in todasCriancas)
		{ 
		    listaRespawnMonstro.Add(crianca.gameObject);
		}		

	}
}
