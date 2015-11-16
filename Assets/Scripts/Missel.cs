using UnityEngine;
using System.Collections;

public class Missel : MonoBehaviour {

	private float velocidade = 10;
	private float tempoDeVida = 10;
	[SerializeField] private int pontosDeDano = 1;
	GameObject alvo;

	void Start()
	{
		alvo = GameObject.Find ("Inimigo");
		CleanGarbage ();
	}
	
	void Update () {
		Anda();
		if (alvo != null) {
			AlteraDirecao ();
		}
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

	private void CleanGarbage(){
		Destroy (this.gameObject, 10);
	}

	void OnTriggerEnter(Collider elemento){
		if (elemento.CompareTag ("Inimigo")) {
			Destroy (this.gameObject);
			Inimigo inimigo = elemento.GetComponent<Inimigo>();
			inimigo.recebeDano(pontosDeDano);
		}
	}

}
