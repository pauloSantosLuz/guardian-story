using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void VoltarMenu()
	{
		int dificuldade = PlayerPrefs.GetInt("dificuldade");
		ConexaoBanco conexaoBanco = new ConexaoBanco();
		//conexaoBanco.SalvarJogo(dificuldade,);
		SceneManager.LoadScene(0);		
	}
}
