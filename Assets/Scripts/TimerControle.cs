using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerControle : MonoBehaviour {
	private float countTime = 0;
	// Update is called once per frame
	void Update () {
		countTime += Time.deltaTime;
		GetComponent<TMPro.TextMeshProUGUI>().text = Mathf.Round(countTime).ToString();		
	}
}
