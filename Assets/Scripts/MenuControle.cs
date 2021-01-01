using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControle : MonoBehaviour {
	public GameObject loadSceneImage;
	// Use this for initialization
	void Start () {
		ConexaoBanco conexao = new ConexaoBanco();
		conexao.CriaTabela();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void IniciarJogo()
	{
		this.loadSceneImage.SetActive(true);
		 SceneManager.LoadScene(1);
	}

	public void Sair()
	{
		Application.Quit();
	}
}
