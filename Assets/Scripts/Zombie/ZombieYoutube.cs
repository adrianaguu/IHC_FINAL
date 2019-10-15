using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;





public class ZombieYoutube : MonoBehaviour {
    private GameObject target;
    private NavMeshAgent agente;
    private Vida vida;
    private Animator animator;
    private Collider collider;
    private Vida vidaJugador;
    private LogicaJugador logicaJugador;
    public bool Vida0 = false;
    public bool estaAtacando = false;
    public float speed = 1.0f;
    public float angularSpeed = 120;
    public float daño = 25;
    public bool atacar = false;
    public float disss =0;
   
    public bool mirando=false;
    //public GameObject bala;
    public float walk_Speed = 1.5f;

	// Use this for initialization


    
	void Start () {
        //target = GameObject.Find("OVRPlayerController");
        
       // target = GameObject.FindWithTag("Player").transform;
       // target = GameObject.Find("Player");
        target = GameObject.Find("Player");
        vidaJugador = target.GetComponent<Vida>();
        if(vidaJugador== null)
        {
            throw new System.Exception("El objeto Jugador no tiene componente Vida");
        }

        logicaJugador = target.GetComponent<LogicaJugador>();
        if (logicaJugador == null)
        {
            throw new System.Exception("El objeto Jugador no tiene componente LogicaJugador");
        }

        agente = GetComponent<NavMeshAgent>();
        vida = GetComponent<Vida>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();

    }
	
	// Update is called once per frame
	void Update () {
        Walk();
        RevisarVida();
        Perseguir();
        EstaDefrenteAlJugador();
        RevisarAtaque();
        
        

        
	}

    void EstaDefrenteAlJugador()
    {
        
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if( Vector3.Angle(Vector3.forward, target.transform.position) < 60f ) //angulo de vision zombie
        {
            if(Vector3.Distance(transform.position, target.transform.position)<20f )
                mirando = true;
            else
                mirando = false;
        }
        else
        {
            mirando = false;
        }


    }

    void RevisarVida()
    {
        if (Vida0) return;
        if(vida.valor <= 0)
        {
            Vida0 = true;
            agente.isStopped = true;
            collider.enabled = false;
            animator.CrossFadeInFixedTime("Vida0", 0.1f);
            Destroy(gameObject, 3f);
        }

    }

    void Walk() //random
    {
        if (Vida0) return;
        if (logicaJugador.Vida0) return;
        //agente.destination = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        agente.destination = new Vector3(Random.Range(-5.0f, 5.0f), 0, Random.Range(-5.0f, 5.0f));
    
    }


    void Perseguir()
    {
        if (Vida0) return;
        if (logicaJugador.Vida0) return;
        if(mirando)
            agente.destination = target.transform.position;
    }

    void RevisarAtaque()
    {
        if (Vida0) return;
        if (estaAtacando) return;
        if (logicaJugador.Vida0){
            return;
        }
        float distanciaDelBlanco = Vector3.Distance(target.transform.position, transform.position);

        //if(distanciaDelBlanco <= 2.0 && mirando)
        
    //Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(target.position)) < 60f
    
            disss = distanciaDelBlanco;
        if(distanciaDelBlanco <= 1.4f )
        {
            Atacar();
            atacar = true;
        //   disss = distanciaDelBlanco;
        
        }
    }


    void Atacar()
    {
        vidaJugador.RecibirDanho(daño);
        agente.speed = 0;
        agente.angularSpeed = 0;
        estaAtacando = true;
        animator.SetTrigger("DebeAtacar");
        Invoke("ReiniciarAtaque", 1.5f);
    }

    void ReiniciarAtaque()
    {
        estaAtacando = false;
        agente.speed = speed;
        agente.angularSpeed = angularSpeed;
    }
    

}
