using UnityEngine;
using System.Collections;

public class Jogador : MonoBehaviour {

    private int vida = 10;

    public void recebeDano()
    {
        vida -= 1;
    }

    public int getVida()
    {
        return vida;
    }

    public bool EstaVivo()
    {
        return vida > 0;
    }
}
