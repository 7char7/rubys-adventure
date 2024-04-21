using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        

        Destroy(gameObject);
        Debug.Log("Object that entered the trigger : " + other);

    }
}