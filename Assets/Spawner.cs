using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject[] arrary;
    public GameObject zombie;
    public float spawnTime = 5;

    void Start()
    {
        InvokeRepeating("spawn", spawnTime, spawnTime);
    }

    void spawn(){
        //Instantiate(projectile, transform.position, transform.rotation);
        Instantiate(zombie , transform.position, transform.rotation);

    }
    // Update is called once per frame
    void Update()
    {
       // Invoke("spawn", spawnTime);
    }
}
