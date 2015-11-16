using UnityEngine;
using System.Collections;

public class Torre : MonoBehaviour {

	public GameObject projetilPrefab;
	public float tempoDeRecarga = 1f;
	private float momentoDoUltimoDisparo = 0;
	[SerializeField]private float raioDeAlcance;

	void Update(){
		Inimigo inimigo = EscolheAlvo ();
		if (inimigo != null) {
			Atira (inimigo);
		}
	}
	
	void Atira (Inimigo inimigo) {
		float tempoAtual = Time.time;
		if (tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga) {
			momentoDoUltimoDisparo = tempoAtual;
			GameObject pontoDeDisparo = this.transform.Find ("CanhaoDaTorre/PontoDeDisparo").gameObject;
			Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
			GameObject projetil = (GameObject) Instantiate (projetilPrefab, posicaoDoPontoDeDisparo, Quaternion.identity);
			Missel missel = projetil.GetComponent<Missel>();
			missel.DefineAlvo(inimigo);
		}
	}

	private Inimigo EscolheAlvo(){
		GameObject[] inimigos = GameObject.FindGameObjectsWithTag ("Inimigo");
		foreach (GameObject inimigo in inimigos) {
			if (EstaNoRaioDeAlcance(inimigo)){
				return inimigo.GetComponent<Inimigo>();
			}
		}
		return null;
	}

	private bool EstaNoRaioDeAlcance(GameObject inimigo){
		Vector3 posicaoDaTorre = this.transform.position;
		Vector3 posicaoDaTorreNoPlano = Vector3.ProjectOnPlane (posicaoDaTorre, Vector3.up);

		Vector3 posicaoDoInimigo = inimigo.transform.position;
		Vector3 posicaoDoInimigoNoPlano = Vector3.ProjectOnPlane (posicaoDoInimigo, Vector3.up);

		float distanciaParaInimigo = Vector3.Distance (posicaoDoInimigoNoPlano, posicaoDoInimigo);

		return distanciaParaInimigo <= raioDeAlcance;

	}
}
