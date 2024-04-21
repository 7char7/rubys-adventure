using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        //checks if the robot has been talked to 
        if (RubyController.talked > 0)
        {
        //this sets the amount of eyes up by 1
        RubyController.eyeCounter += 1;

        Destroy(gameObject);


        }
        

    }
}