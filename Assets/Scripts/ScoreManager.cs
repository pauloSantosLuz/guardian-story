using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public int pontuacao = 0;
	public GameObject textPontuacao;

	void Start () {
	}
	
	void Update () {
		textPontuacao.GetComponent<TMPro.TextMeshProUGUI>().text = pontuacao.ToString();
	}
}
