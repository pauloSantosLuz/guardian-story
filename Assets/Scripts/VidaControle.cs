using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaControle : MonoBehaviour {
	public Stack vida = new Stack();
	public GameObject vidaUI;
	public GameObject vidaControle;
	// Use this for initialization
	void Start () {
		int dificuldade = PlayerPrefs.GetInt("dificuldade");

		switch(dificuldade)
		{
			case 1: IniciaVida(4); break;
			case 2: IniciaVida(3); break;
			case 3: IniciaVida(2); break;
			case 4: IniciaVida(1); break; 

		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void IniciaVida(int numVida)
	{
		for(int i = 0; i < numVida; i++)
		{
			if(i == 0)
			{
				vidaUI.SetActive(true);
				vida.Push(vidaUI);
			}else
			{
				GameObject ultimaVida = (GameObject)vida.Peek();
				Vector2 posicao = ultimaVida.transform.localPosition;
				posicao.x = posicao.x + 56; 				
				var instancia = Instantiate(vidaUI,
					vidaUI.transform.position,vidaUI.transform.rotation);

				instancia.transform.parent = vidaControle.transform;
				instancia.transform.localPosition = posicao;
				instancia.transform.localScale = ultimaVida.transform.localScale;				
				vida.Push(instancia);				
			}

		}
	}
	public void PerdeVida()
	{
		GameObject vidaPerdida = (GameObject)this.vida.Pop();
		Destroy(vidaPerdida);
	}

	public int GetNumVida()
	{
		return this.vida.Count;
	}


}
