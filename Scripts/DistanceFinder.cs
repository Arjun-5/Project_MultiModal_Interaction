using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceFinder : MonoBehaviour
{
    public GameObject Postion_No;
    public GameObject Postion_Player;
    public GameObject Postion_No_1;
    public GameObject Postion_Player_1;


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "car_Position_Player")
        {
            Postion_No.GetComponent<Text>().text = "1";
            Postion_Player.GetComponent<Text>().text = "Master";
            Postion_No_1.GetComponent<Text>().text = "2";
            Postion_Player_1.GetComponent<Text>().text = "AI";
        }
    }
}