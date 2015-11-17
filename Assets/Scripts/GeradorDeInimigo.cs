using UnityEngine;
using System.Collections;

public class GeradorDeInimigo : MonoBehaviour {

	[SerializeField]private GameObject inimigo;

    [SerializeField]
    private float tempoDeGeracao = 2f;

	private float momentoDaUltimaGeracao;

	void Update () {
		GeraInimigo ();
	}

	private void GeraInimigo(){

		float tempoAtual = Time.time;

		if (tempoAtual > momentoDaUltimaGeracao + tempoDeGeracao) {
			momentoDaUltimaGeracao = tempoAtual;
			Instantiate (inimigo, this.transform.position, Quaternion.identity);
		}
		
	}
}
