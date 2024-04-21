using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class managerScript : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameWonUI()
    {
        Win.SetActive(true);

    }
       
    public void gameLostUI()
    {
        Lost.SetActive(true);
    }
   
}
