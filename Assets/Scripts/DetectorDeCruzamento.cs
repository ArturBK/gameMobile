using UnityEngine;
using System.Collections;

public class DetectorDeCruzamento : MonoBehaviour {

    [SerializeField]private Jogador jogador;

    void OnTriggerEnter(Collider inimigo)
    {
            
        Destroy(inimigo.gameObject);
        if (inimigo.gameObject.CompareTag("Inimigo"))
        {
            jogador.recebeDano();
        }
    }
}
