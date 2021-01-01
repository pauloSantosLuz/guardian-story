using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaGeloManager : MonoBehaviour {
	public GameObject origemMagia;

	void Start () {
		this.origemMagia = GameObject.Find("OrigemMagia");
		transform.position = origemMagia.transform.position;		
	}
	
	void FixedUpdate () {
		transform.position = origemMagia.transform.position + origemMagia.transform.forward ;				
		
	}

	void lateUpdate () {
//		transform.position = origemMagia.transform.position;				
	}
}