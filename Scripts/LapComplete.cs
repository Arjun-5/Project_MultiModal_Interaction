using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
public class LapComplete : MonoBehaviour
{
    //public GameObject lapComplete_Trigger;
    public GameObject LapCounter;
    public int counter;
    private bool iscolliding;
    public GameObject carControls_1;
    public GameObject AICar_1;
    CarController car_Object_1;
    CarController car_AI_Object_1;
    public GameObject game_OverText;
    public GameObject player_Name_Winner;
    string winnerText;

    private void Start()
    {
        car_Object_1 = carControls_1.GetComponent<CarController>();
        car_AI_Object_1 = AICar_1.GetComponent<CarController>();
        counter = 1;
        LapCounter.GetComponent<Text>().text = counter.ToString();
        iscolliding = false;
    }
   
    private void OnTriggerEnter(Collider objectName)
    {
        if (objectName.tag == "Collider_Tag")
        {
            if (counter >= 2)
            {
                car_Object_1.enabled = false;
                car_AI_Object_1.enabled = false;
                winnerText = player_Name_Winner.GetComponent<Text>().text;
                game_OverText.GetComponent<Text>().text = "Game Over!!! "+ winnerText+" wins. Better Luck next time";
            }
            else
            {
                if (!iscolliding)
                {
                    iscolliding = true;
                    counter = counter + 1;
                    LapCounter.GetComponent<Text>().text = counter.ToString();
                }
            }
        }
    }
    private void OnTriggerExit()
    {
        if (iscolliding)
            iscolliding = false;
    }
}
