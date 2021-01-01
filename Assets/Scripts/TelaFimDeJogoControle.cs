using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaFimDeJogoControle : MonoBehaviour {
	public GameObject score;
	public GameObject scorePainel;
	public GameObject timer;
	public GameObject timerPainel;


	void Start () {
		scorePainel.GetComponent<TMPro.TextMeshProUGUI>().text = 
			score.GetComponent<TMPro.TextMeshProUGUI>().text;	

		timerPainel.GetComponent<TMPro.TextMeshProUGUI>().text = 
			timer.GetComponent<TMPro.TextMeshProUGUI>().text;	

	}

	public void BotaoRecomecar()
	{
		string dificuldade = PlayerPrefs.GetInt("dificuldade").ToString();
		string pontuacao = score.GetComponent<TMPro.TextMeshProUGUI>().text;
		string tempo = timer.GetComponent<TMPro.TextMeshProUGUI>().text;

		ConexaoBanco conexaoBanco = new ConexaoBanco();
		conexaoBanco.SalvarJogo(dificuldade,pontuacao,tempo);
		SceneManager.LoadScene(1);		
	}

	public void BotaoRetornar()
	{
		string dificuldade = PlayerPrefs.GetInt("dificuldade").ToString();
		string pontuacao = score.GetComponent<TMPro.TextMeshProUGUI>().text;
		string tempo = timer.GetComponent<TMPro.TextMeshProUGUI>().text;

		ConexaoBanco conexaoBanco = new ConexaoBanco();
		conexaoBanco.SalvarJogo(dificuldade,pontuacao,tempo);
		SceneManager.LoadScene(0);		
	}

	public void BotaoAvaliar()
	{
		//Abrir popup de avaliar jogo;
	}
	
}
