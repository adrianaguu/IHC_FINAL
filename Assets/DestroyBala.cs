using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBala : MonoBehaviour
{
    public GameObject Bala;



    void OnCollisionEnter(Collision other)
    {
        //Instantiate(Bala, transform.position, Quaternion.identity);
        Destroy(gameObject, 2f);
    }
    
}
