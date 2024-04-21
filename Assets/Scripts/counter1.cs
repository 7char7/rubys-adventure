using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RubyController.enemyCounter !=1)
        GameObject.Find ("1").transform.localScale = new Vector3(0, 0, 0);
        else 
        GameObject.Find ("1").transform.localScale = new Vector3(1, 1, 1);    
    }
}
