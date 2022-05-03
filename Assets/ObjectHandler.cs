using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHandler : MonoBehaviour
{

    /* private void OnCollisionEnter2D(Collision2D other)
     {

         Debug.Log("Trigger called");
         if (other.gameObject.name == "Bullseye")
         {
             //score+=50
             PlayerManager.scoreCount += 50;

         }
         else if (other.gameObject.name == "Circle1")
         {
             //score+=25
             PlayerManager.scoreCount += 25;

         }
         else if (other.gameObject.name == "Circle2")
         {
             //score+=10
             PlayerManager.scoreCount += 10;

         }
         Destroy(gameObject);
     }*/
    bool circle2 = false;
    bool circle1 = false;
    bool bullseye = false;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision detected");
        if (other.gameObject.name == "Circle2")
        {
            Debug.Log("Outer circle entered");
            PlayerManager.scoreCount += 10;
        }
        if (other.gameObject.name == "Circle1")
        {
            Debug.Log("inner circle entered");
            PlayerManager.scoreCount += 15;
            circle1 = true;
        }
        if (other.gameObject.name == "Bullseye")
        {
            Debug.Log("bulls eye entered");
            PlayerManager.scoreCount += 25;
            bullseye = true;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

}
