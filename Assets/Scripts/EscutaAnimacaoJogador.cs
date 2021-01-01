using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscutaAnimacaoJogador : MonoBehaviour {
	public LancaMagia lancaMagia;

	public void PodeLancar()
	{
		GetComponent<EscutaAnimacaoJogador>().lancaMagia.podeCastar = true;
	}
}
