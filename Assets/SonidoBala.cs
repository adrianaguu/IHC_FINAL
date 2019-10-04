using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBala : MonoBehaviour
{
    public AudioClip GunSound;
    AudioSource fuente;
    public Transform puntoDeDisparo;
    void Start()
    {
        fuente =  GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
        //if (Input.GetButtonDown("Fire1")){
        if( (Input.GetButtonDown("Fire1") || (KinectManager.instance.IsAvailable && KinectManager.instance.IsFire)) ){
         //  fuente.clip = GunSound;
           // fuente.Play();


/* 
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
            */
            
        }
        
    }
}
