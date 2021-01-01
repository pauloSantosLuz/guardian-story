using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownControle : MonoBehaviour {
	public GameObject iconMagiaFogo;
	public GameObject iconMagiaGelo;
	public GameObject iconMagiaTerra;
	public GameObject iconMagiaExplosao;

	public Text txtCdFogo;
	public Text txtCdGelo;
	public Text txtCdTerra;
	public Text txtCdExplosao;

	private Color corMagiaFogo;
	private Color corMagiaGelo;
	private Color corMagiaTerra;
	private Color corMagiaExplosao;

	void Start(){
		this.corMagiaFogo = this.iconMagiaFogo.GetComponent<Image>().color;
		this.corMagiaGelo = this.iconMagiaGelo.GetComponent<Image>().color;
		this.corMagiaTerra = this.iconMagiaTerra.GetComponent<Image>().color;
		this.corMagiaExplosao = this.iconMagiaExplosao.GetComponent<Image>().color;
	}

	public void AtualizaCdFogo(float cdFogo)
	{
		if(cdFogo < 0f)
		{
			this.txtCdFogo.gameObject.SetActive(false);
			return;
		}else
		{

			this.corMagiaFogo.a = 1f - (0.8f/1.5f)*cdFogo;
			this.txtCdFogo.gameObject.SetActive(true);
			this.txtCdFogo.text = Mathf.Round(cdFogo).ToString();
			Debug.Log(this.corMagiaFogo.a);
		}

		this.iconMagiaFogo.GetComponent<Image>().color = corMagiaFogo;
	}	

	public void AtualizaCdGelo(float cdGelo)
	{
		if(cdGelo < 0f)
		{
			this.txtCdGelo.gameObject.SetActive(false);
			return;
		}else
		{
			this.corMagiaGelo.a = 1f - (0.8f/5f)*cdGelo;
			this.txtCdGelo.gameObject.SetActive(true);
			this.txtCdGelo.text = Mathf.Round(cdGelo).ToString();
		}
		this.iconMagiaGelo.GetComponent<Image>().color = corMagiaGelo;
	}	

	public void AtualizaCdTerra(float cdTerra)
	{
		if(cdTerra < 0f)
		{
			this.txtCdTerra.gameObject.SetActive(false);
			return;
		}else
		{
			this.corMagiaTerra.a = 1f - (0.8f/10f)*cdTerra;
			this.txtCdTerra.gameObject.SetActive(true);
			this.txtCdTerra.text = Mathf.Round(cdTerra).ToString();
		}
		this.iconMagiaTerra.GetComponent<Image>().color = corMagiaTerra;
	}	
	public void AtualizaCdExplosao(float cdExplosao)
	{
		if(cdExplosao < 0f)
		{
			this.txtCdExplosao.gameObject.SetActive(false);
			return;
		}else
		{
			this.corMagiaExplosao.a = 1f - (0.8f/20f)*cdExplosao;
			this.txtCdExplosao.gameObject.SetActive(true);
			this.txtCdExplosao.text = Mathf.Round(cdExplosao).ToString();
		}
		this.iconMagiaExplosao.GetComponent<Image>().color = corMagiaExplosao;
	}	
}
