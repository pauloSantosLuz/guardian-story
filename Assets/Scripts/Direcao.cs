using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Classe para controlar a direção do boneco principal */
public class Direcao : MonoBehaviour {
	public Transform posicao;
	void Start () {
		this.posicao = GetComponent<Transform>();
	}
	
	void FixedUpdate () {
		if(Input.GetKey("a"))
			this.posicao.Rotate(0f,-1f,0f);

		if(Input.GetKey("d"))
			this.posicao.Rotate(0f,1f,0f);
		
	}
}
