using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTime_Calculator : MonoBehaviour
{
    public static int minute_Count;
    public static int second_Count;
    public static float milliSecond;
    public static string milliDisplay;

    public GameObject minuteBox;
    public GameObject secondBox;
    public GameObject millisecondBox;

    // Update is called once per frame
    void Update()
    {
        milliSecond = Time.deltaTime* 1000;
        milliDisplay = milliSecond.ToString();
        millisecondBox.GetComponent<Text>().text= "" + milliDisplay;
        if (milliSecond >= 10)
        {
            milliSecond = 0;
            second_Count += 1;
        }
        if (second_Count <= 9)
        {
            secondBox.GetComponent<Text>().text = "0" + second_Count+".";
        }
        else
        {
            secondBox.GetComponent<Text>().text = ""+second_Count + ".";
        }
        if (second_Count >= 60)
        {
            second_Count = 0;
            minute_Count += 1;
        }
        if (minute_Count <= 9)
        {
            minuteBox.GetComponent<Text>().text = "0" + minute_Count + ":";
        }
        else
        {
            minuteBox.GetComponent<Text>().text = ""+minute_Count + ":";
        }
    }
}
