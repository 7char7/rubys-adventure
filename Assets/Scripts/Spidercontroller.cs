using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spidercontroller : MonoBehaviour
{
    public float displayTime = 4.0f;
    float timerDisplay;
    public GameObject ZeroText;
    public GameObject OneText;
    public GameObject TwoText;
    public GameObject ThreeText;
    public GameObject FourText;

    //sets all the text boxes to false
    void Start()
    {
        ZeroText.SetActive(false);
        OneText.SetActive(false);
        TwoText.SetActive(false);
        ThreeText.SetActive(false);
        FourText.SetActive(false);
        timerDisplay = -1.0f;
    }
    //sets all the text boxes to false after a timer 
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                ZeroText.SetActive(false);
                OneText.SetActive(false);
                TwoText.SetActive(false);
                ThreeText.SetActive(false);
                FourText.SetActive(false);
            }
        }
    }
    //display text when zero eyes are picked up
    public void DisplayZero()
    {
        timerDisplay = displayTime;
        ZeroText.SetActive(true);
        RubyController.talked += 1;
    }
    //display text when one eyes are picked up
    public void DisplayOne()
    {
        timerDisplay = displayTime;
        OneText.SetActive(true);
        RubyController.talked += 1;
    }
    //display text when two eyes are picked up
    public void DisplayTwo()
    {
        timerDisplay = displayTime;
        TwoText.SetActive(true);
        RubyController.talked += 1;
    }
    //display text when three eyes are picked up
    public void DisplayThree()
    {
        timerDisplay = displayTime;
        ThreeText.SetActive(true);
        RubyController.talked += 1;
    }
    //display text when four eyes are picked up, the total amount of eyes
    public void DisplayFour()
    {
        timerDisplay = displayTime;
        FourText.SetActive(true);
        RubyController.talked += 1;
    }


}
