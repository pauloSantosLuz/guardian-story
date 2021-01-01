using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaFogoManager : MonoBehaviour {
	public GameObject explosionPrefab;

	void Start(){
		explosionPrefab =  GameObject.Find("OrigemMagia")
			.GetComponent<LancaMagia>().explosao;
	}

	public void OnCollisionEnter(Collision collision)
	{
		explosionPrefab = GetComponent<MagiaFogoManager>().explosionPrefab;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        
        var instancia = Instantiate(explosionPrefab, pos, rot);

        Destroy(this.gameObject);
        Destroy(instancia,2f);
	}
}
