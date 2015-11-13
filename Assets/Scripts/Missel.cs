using UnityEngine;
using System.Collections;

public class Missel : MonoBehaviour {

	private float velocidade = 10;
	GameObject alvo;

	void Start()
	{
		alvo = GameObject.Find ("Inimigo");
	}
	
	void Update () {
		Anda();
		AlteraDirecao ();
	}

	private void Anda(){
		Vector3 posicaoAtual = transform.position;
		Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
		transform.position = posicaoAtual + deslocamento;

	}

	private void AlteraDirecao(){
		Vector3 posicaoAtual = transform.position;
		Vector3 posicaoDoAlvo = alvo.transform.position;

		Vector3 direcaoDoAlvo = posicaoDoAlvo - posicaoAtual;

		transform.rotation = Quaternion.LookRotation (direcaoDoAlvo);
	}

}
