using UnityEngine;
using System.Collections;

public class Missel : MonoBehaviour {

	private float velocidade = 10;
	private float tempoDeVida = 10;
	[SerializeField] private int pontosDeDano = 1;
	private Inimigo alvo;

	void Start()
	{
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

	public void DefineAlvo(Inimigo inimigo){
		alvo = inimigo;
	}

	void OnTriggerEnter(Collider elemento){
		if (elemento.CompareTag ("Inimigo")) {
			Destroy (this.gameObject);
			Inimigo inimigo = elemento.GetComponent<Inimigo>();
			inimigo.recebeDano(pontosDeDano);
		}
	}

}
