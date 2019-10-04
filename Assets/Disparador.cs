using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed = 10;
    public AudioClip GunSound;
    AudioSource fuente;
    public Transform puntoDeDisparo;
    bool couroutineStarted= false;

    void Start(){
        fuente =  GetComponent<AudioSource>();
   }

    void Update()
    {
        if(!couroutineStarted)
            StartCoroutine( disparar() );
    
    }

    
    IEnumerator  disparar(){
        if ( (Input.GetButtonDown("Fire1") || (KinectManager.instance.IsAvailable && KinectManager.instance.IsFire))  ){ // && ballInPlay == false){ 
                couroutineStarted = true;

                fuente.clip = GunSound;
                fuente.Play();

                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);
                instantiatedProjectile.velocity = transform.TransformDirection( Vector3.forward*50);
                Physics.IgnoreCollision( instantiatedProjectile.GetComponent<Collider>(), transform.root.GetComponent<Collider>() );
                
                RaycastHit hit;
                if(Physics.Raycast(puntoDeDisparo.position, puntoDeDisparo.forward, out hit))
                {
                    if (hit.transform.CompareTag("Enemigo"))
                    {
                        Vida vida = hit.transform.GetComponent<Vida>();
                        if(vida == null)
                        {
                            throw new System.Exception("No se encontro el componente Vida del Enemigo");
                        }
                        else
                        {
                            vida.RecibirDanho(25);
                        }
                    }
                }
                yield return new WaitForSeconds(0.5f);
                couroutineStarted = false;

      }
   }

   
}
