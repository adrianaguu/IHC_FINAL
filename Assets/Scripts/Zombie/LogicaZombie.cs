using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* 

public enum EnemyState {
    PATROL,
    WALK,
    ATTACK,
    DEAD
}
*/

public class LogicaZombie : MonoBehaviour
{

    /* 
    private GameObject target;
     private NavMeshAgent Agente;
     private Vida vidaZombie;
     private Animator animator;
     private Collider collider;
     public Vida vidaPlayer;
     private LogicaJugador logicaJugador;
     public bool death = false;     
     public bool estaAtacando = false;
     public float speed = 1.0f;
     public float angularspeed = 120;
     public float daño = 20;
     public bool EstaMirando = false;
     private float walk_Speed = 1.5f;
     private float patrol_Timer = 15f;

    EnemyState enemy_State;
    
    void Start()
    {
        target = GameObject.Find("Player");
        vidaPlayer = target.GetComponent<Vida>();
        if(vidaPlayer == null){
            throw new System.Exception("Error Jugador no tiene Comp Vida");
        }
        logicaJugador = target.GetComponent<LogicaJugador>();

        Agente = GetComponent<NavMeshAgent>();
        vidaZombie = GetComponent<Vida>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
        enemy_State = EnemyState.WALK;
    }


    void Update()
    {
        if(enemy_State == EnemyState.PATROL) {
            Patrol();
        }

        if(enemy_State == EnemyState.WALK) {
            Perseguir();
        }

        if (enemy_State == EnemyState.ATTACK) {
            Atacar();
        }

        if (enemy_State == EnemyState.DEAD) {
            Perseguir();
            //Dead();
        }
        //RevisaVida();
        //Perseguir();
       // RevisarAtaque();
        //Atacar();
    }

    void EstadeFrenteDelPlayer(){
        Vector3 adelante = transform.forward;
        Vector3 targetJugador = (GameObject.Find("Player").transform.position - transform.position).normalized;

        if(Vector3.Dot(adelante,targetJugador)< 0.1f)
        {
            EstaMirando = false;
        }
        else
        {
            EstaMirando = true;
        }
    }

    void RevisaVida()
    {
        if (death){return;}
        if(vidaZombie.valor <= 0)
        {
            death = true;
            Agente.isStopped = true;
            collider.enabled = false;
            animator.CrossFadeInFixedTime("death", 0.1f);
            
            animator.SetBool("death", true);
            Destroy(gameObject, 3f);
        }

    }    
    void Perseguir()
    {
        if (death) {return;}
        if (logicaJugador.death){return;}
        Agente.isStopped = true;
        Agente.destination = target.transform.position;
    }

    void RevisarAtaque()
    {
        if (death){return;}
        //if (estaAtacando){return;}
        if (logicaJugador.death){
            animator.SetBool("DebeAtacar", false);
            Agente.isStopped = true;
        }

        float distanciaDelBlanco = Vector3.Distance(target.transform.position, transform.position);
        if(distanciaDelBlanco <= 2.0 && EstaMirando)
        {
            Atacar();
        }
    }

    void Atacar()
    {
        RevisarAtaque();
        vidaPlayer.Recibirdaño(daño);
        Agente.speed = 0;
        Agente.angularSpeed = 0;
        estaAtacando = true;
        //animator.SetTrigger("DebeAtacar");
        animator.SetBool("DebeAtacar", true);
        //Invoke("ReiniciarAtaque", 3.5f);
    }

    void Patrol() {
        // tell nav agent that he can move
        Agente.isStopped = false;
        Agente.speed = walk_Speed;
        // add to the patrol timer
        patrol_Timer += Time.deltaTime;

        if(patrol_Timer > 15f) {
            SetNewRandomDestination();
            patrol_Timer = 0f;
        }

        if(Agente.velocity.sqrMagnitude > 0) {
            animator.SetBool("walk", true);
        } else {
            animator.SetBool("walk", false);
        }

        if(Vector3.Distance(transform.position, target.position) <= 7f) {
            animator.SetBool("walk", true);
            enemy_State = EnemyState.WALK;
            // play spotted audio
            //enemy_Audio.Play_ScreamSound();

        }

     
    } // patrol

/* 
    void ReiniciarAtaque()
    {
        estaAtacando = false;        
        animator.SetBool("DebeAtacar", false);
        Agente.speed = speed;
        Agente.angularSpeed = angularspeed;
    }
    *****************************


    void SetNewRandomDestination() {

        float rand_Radius = Random.Range(20f, 60f);

        Vector3 randDir = Random.insideUnitSphere * rand_Radius;
        randDir += transform.position;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDir, out navHit, rand_Radius, -1);

        Agente.SetDestination(navHit.position);

    }
    void Dead(){
        return;

    }

*/
}



