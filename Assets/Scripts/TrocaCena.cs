using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrocaCena : MonoBehaviour {
	public GameObject menuPrincipal;
	public GameObject telaDeCarregamento;
	public GameObject textoLoading;
	public GameObject barraDeCarregamento;

	public void MudaCena(int indexCena)
	{
		menuPrincipal.SetActive(false);
		telaDeCarregamento.SetActive(true);
		StartCoroutine(TrocaCenaAssincronamente(indexCena));		
	}

	IEnumerator TrocaCenaAssincronamente(int indexCena)
	{
		AsyncOperation operacao = SceneManager.LoadSceneAsync(indexCena);
		while(!operacao.isDone)
		{
			float progresso = Mathf.Clamp01(operacao.progress/0.9f);
			barraDeCarregamento.GetComponent<Slider>().value = progresso;

			progresso *= 100f;
			int mostraProgresso = (int)progresso;

			textoLoading.GetComponent<TMPro.TextMeshProUGUI>().text = mostraProgresso.ToString() + "%";

			yield return null;
		}
	}
}
