using UnityEngine;
using System.Collections;

public class Jogo : MonoBehaviour {

	[SerializeField]private GameObject torrePrefab;
    [SerializeField]private GameObject gameOver;
    [SerializeField]private Jogador jogador;

    void Start()
    {
        gameOver.SetActive(false);
    }

	void Update(){

        if (!JogoAcabou())
        {
            gameOver.SetActive(true);
        }
        else { 
            if (clicouComBotaoPrimario()) {
			    ConstroiTorre();
		    }
        }
    }

    public void recomecaJogo()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    private bool JogoAcabou()
    {
        return jogador.EstaVivo();
    }

    private bool clicouComBotaoPrimario(){
		return Input.GetMouseButtonDown (0);
	}

	private void ConstroiTorre(){
		Vector3 posicaoDoClique = Input.mousePosition;
		RaycastHit elementoAtingidoPeloRaio = DisparaRaioDaCameraAteUmPonto (posicaoDoClique);
	
		if (elementoAtingidoPeloRaio.collider != null) {
			Vector3 posicaoDeCriacaoDaTorre = elementoAtingidoPeloRaio.point;
			Instantiate(torrePrefab, posicaoDeCriacaoDaTorre, Quaternion.identity);
		}
	}

	private RaycastHit DisparaRaioDaCameraAteUmPonto(Vector3 ponto){
		Ray raio = Camera.main.ScreenPointToRay (ponto);
		float comprimentoMaximoDoRaio = 100.0f;
		RaycastHit elementoAtingidoPeloRaio;
		Physics.Raycast (raio, out elementoAtingidoPeloRaio, comprimentoMaximoDoRaio);

		return elementoAtingidoPeloRaio;
	}
}
