using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LogicaJugador : MonoBehaviour {
    public Vida vida;
    public bool Vida0 = false;

	void Start () {
        //gameObject.name = "Player";
        vida = GetComponent<Vida>();
	}
	
	void Update () {
        RevisarVida();
	}

    void RevisarVida()
    {
        if (Vida0){return;}
        if(vida.valor <= 0)
        {
            Vida0 = true;
            Invoke("ReiniciarJuego", 2f);
        }
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
}

