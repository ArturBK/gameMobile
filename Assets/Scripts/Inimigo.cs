using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NavMeshAgent agente = GetComponent<NavMeshAgent> ();
		GameObject fim = GameObject.Find ("FimDoCaminho");
		agente.SetDestination (fim.transform.position);
	}
}
