using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicasAmbienteModel : MonoBehaviour {
	public AudioClip[] musicaJogo = new AudioClip[3];
	public AudioClip musicaMenu;
	public AudioClip[] musicaFimDeJogo = new AudioClip[3];

	public AudioSource somGame;

	public void TocaMusicaInicial()
	{
		int index = Random.Range(0,musicaJogo.Length);
		somGame.clip = musicaJogo[index];
		somGame.Play();
	}

	public void TocaMusicaFinal()
	{
		int index = Random.Range(0,musicaFimDeJogo.Length);
		somGame.clip = musicaFimDeJogo[index];
		somGame.Play();
	}
}



