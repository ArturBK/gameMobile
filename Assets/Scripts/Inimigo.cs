using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	[SerializeField]private int vida = 10;

	void Start () {
		NavMeshAgent agente = GetComponent<NavMeshAgent> ();
		GameObject fim = GameObject.Find ("FimDoCaminho");
		agente.SetDestination (fim.transform.position);
	}

	public void recebeDano(int pontosDeDano){
		vida -= pontosDeDano;
		if (vida <= 0) {
			Destroy(this.gameObject);
		}
	}
}
