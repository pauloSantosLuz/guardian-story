using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class MostraRecorde : MonoBehaviour {
	public GameObject Dificuldade;
	public GameObject Pontuacao;
	public GameObject Timer;
	public ConexaoBanco conexaoBanco;

	void OnEnable(){
		conexaoBanco.ListaRecordes();
	}

	void OnDisable(){

	}
}
