using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoDificuldadeControle : MonoBehaviour {
	public Image[] imagensBotoes = new Image[4] ;
	public int dificuldade = 0;

	void OnEnable(){
		AtualizaDificuldade(1);
	}

	public void AtualizaDificuldade(int dificuldade)
	{
		foreach(Image imagem in imagensBotoes)
		{
			imagem.color = Color.black;
		}

		switch(dificuldade)
		{
			case 1:
		    	for(int i = 0; i < 1; i++)
		    		imagensBotoes[i].color = Color.white;
		    	this.dificuldade = 1;
		    	break;

			case 2:
		    	for(int i = 0; i < 2; i++)
		    		imagensBotoes[i].color = Color.white;
		    	this.dificuldade = 2;
		    	break;

			case 3:
		    	for(int i = 0; i < 3; i++)
		    		imagensBotoes[i].color = Color.white;
		    	this.dificuldade = 3;
		    	break;

			case 4:
		    	for(int i = 0; i < 4; i++)
		    		imagensBotoes[i].color = Color.white;
		    	this.dificuldade = 4;
		    	break;
		}
		PlayerPrefs.SetInt("dificuldade",dificuldade);
	}

}
