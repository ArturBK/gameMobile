﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MostradorDeVida : MonoBehaviour {

    private Text campoTexto;
    [SerializeField]private Jogador jogador;

	void Start () {
		campoTexto = GetComponent<Text> ();
	}
	
	void Update () {
        campoTexto.text = "Vida: " + jogador.getVida();
	}
}
