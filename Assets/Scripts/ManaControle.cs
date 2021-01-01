using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaControle : MonoBehaviour {
	public Stack mana = new Stack();
	public GameObject manaObject;
	private float countTempo = 0f;
	public GameObject manaControle;
	private float cdMana;
	void Start () {
		int dificuldade = PlayerPrefs.GetInt("dificuldade");

		switch(dificuldade)
		{
			case 1: cdMana = 2f; break;
			case 2: cdMana = 2.5f; break;
			case 3: cdMana = 3f; break;
			case 4: cdMana = 3.5f; break; 

		}

		IniciaMana();
	}
	
	void Update () {
		
	}

	void FixedUpdate () {
		countTempo += Time.deltaTime;
		if(countTempo >= cdMana)
			RespawnMana();
	}

	public void RespawnMana()
	{
		if(mana.Count == 0)
		{
			var instancia = Instantiate(manaObject,
					manaObject.transform.position,manaObject.transform.rotation);

			instancia.transform.parent = manaControle.transform;
			instancia.transform.localPosition = instancia.transform.position;
			instancia.transform.localScale = new Vector3(0.8f,0.6f,0.8f);
			mana.Push(instancia);

		}
		else
		{
			if(mana.Count < 4)
			{
				GameObject ultimaMana = (GameObject)mana.Peek();
				Vector2 posicao = ultimaMana.transform.localPosition;
				posicao.x = posicao.x + 53; 
				var instancia = Instantiate(manaObject,
					manaObject.transform.position,manaObject.transform.rotation);

				instancia.transform.parent = manaControle.transform;
				instancia.transform.localPosition = posicao;
				instancia.transform.localScale = new Vector3(0.8f,0.6f,0.8f);				
				mana.Push(instancia);				
			}

		}
		countTempo = 0f;
	}

	public void GastaMana(int manaGasta)
	{
		for(int i = 0; i < manaGasta; i++)
		{
			GameObject manaRetirada = (GameObject)mana.Pop();
			manaRetirada.SetActive(false);
		}
	}

	public int ManaDisponivel()
	{
		return mana.Count;
	}
	public void IniciaMana()
	{
		for(int i = 1; i <= 4; i++)
		{
			RespawnMana();
		}		

	}
}
