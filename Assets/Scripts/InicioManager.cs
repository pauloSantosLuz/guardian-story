using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioManager : MonoBehaviour {
    public Texture2D cursorTexture;

    public GameObject respawnCrianca;
	public GameObject respawnJogador;
	public GameObject kid;
	public MusicasAmbienteModel musicasAmbienteModel;
	void Awake()
	{
	}
	void Start () {
		Time.timeScale = 1f;
	 	Cursor.SetCursor(cursorTexture, new Vector2(32,32),  CursorMode.Auto);
		Cursor.visible = true;
	 	respawnCrianca.SetActive(true);
		respawnJogador.SetActive(true);
		Invoke("IniciaPersonagens",2f);
		musicasAmbienteModel.TocaMusicaInicial();
		
	}
	
	void Update () {
		
	}

	public void IniciaPersonagens()
	{
		kid.SetActive(true);
		respawnCrianca.SetActive(false);
		respawnJogador.SetActive(false);
	}
}
