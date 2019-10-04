using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    public Transform padre;
    public float HorizontalSpeed = 2;
    public float VerticalSpeed = 2;
    public float currentRotationX;
    private float RotadorPistola;
    

    float H;
    float V;
    void Start()
    {
        padre = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       // H = ( HorizontalSpeed*Input.GetAxis("Mouse X") ); // || Oculus )
        //V = ( VerticalSpeed*Input.GetAxis("Mouse Y") ); // || Oculus )
     //   V = ( VerticalSpeed*Mathf.Clamp(float value, float min, float max) ); // || Oculus )
     float maxRotationX=8f;
            float minRotationX=330f;
             float landmark=200f;
         if (KinectManager.instance.IsAvailable)
        {    
            RotadorPistola = KinectManager.instance.RotationPistola;
            currentRotationX = padre.eulerAngles.x;
    
           
            if (currentRotationX> maxRotationX && currentRotationX< minRotationX)
            {
                if(currentRotationX< landmark)
                    padre.Rotate(-0.07f,0,0);
                else
                {
                    padre.Rotate(0.07f,0,0);
                }
            }
                    
            else
            {
                padre.Rotate(RotadorPistola  ,0 ,0 );
            } 
          
        }
        else
        {
            H = ( HorizontalSpeed*Input.GetAxis("Mouse X") ); 
            V = ( VerticalSpeed*Input.GetAxis("Mouse Y") ); 
            //V = ( VerticalSpeed*Mathf.Clamp(float value, float min, float max) );
          /*   currentRotationX = padre.eulerAngles.x;
            float variationRotation=currentRotationX+V;
            if (currentRotationX> maxRotationX && currentRotationX< minRotationX)
            {
                if(currentRotationX< landmark)
                    padre.Rotate(-0.07f,0,0);
                else
                {
                    padre.Rotate(0.07f,0,0);
                }
            }
                    
            else
            {*/
                padre.Rotate(V,0,0);
              
            //}
        }


    }
}
