using UnityEngine;
using System.Collections;

public class Torre : MonoBehaviour {

	public GameObject projetilPrefab;
	public float tempoDeRecarga = 1f;
	private float momentoDoUltimoDisparo = 0;


	void Start () {
		Atira ();
	}

	void Update(){
		Atira ();
	}
	
	void Atira () {
		float tempoAtual = Time.time;
		if (tempoAtual > momentoDoUltimoDisparo + tempoDeRecarga) {
			momentoDoUltimoDisparo = tempoAtual;
			GameObject pontoDeDisparo = this.transform.Find ("CanhaoDaTorre/PontoDeDisparo").gameObject;
			Vector3 posicaoDoPontoDeDisparo = pontoDeDisparo.transform.position;
			Instantiate (projetilPrefab, posicaoDoPontoDeDisparo, Quaternion.identity);
		}
	}
}
