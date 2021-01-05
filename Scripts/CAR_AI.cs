using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class CAR_AI : MonoBehaviour
{
    private KeywordRecognizer Input_Recognizer_Auto;
    private Dictionary<string, Action> keyword = new Dictionary<string, Action>();
    public GameObject[] wayPoints_for_AI;
    //public CarAIControl AI_Car;
    //public CarAIControl AI_Car_1;
    public GameObject pointReference;
    private int index;
    CarController car_AI_Object_Auto;
    CarController car_AI_Object_Auto_1;
    public GameObject AICar_Auto;

    //public GameObject AICar_Auto_1;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;

        car_AI_Object_Auto = AICar_Auto.GetComponent<CarController>();
        

        keyword.Add("Autopilot", autoPilot_enable);
       // keyword.Add("Exit", autoPilot_disable);

        Input_Recognizer_Auto = new KeywordRecognizer(keyword.Keys.ToArray());
        Input_Recognizer_Auto.OnPhraseRecognized += RecognizedSpeech;
        Input_Recognizer_Auto.Start();
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        keyword[speech.text].Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void autoPilot_enable()
    {
        car_AI_Object_Auto.enabled = true;
        //car_AI_Object_Auto_1.enabled = true;
    }
    private void autoPilot_disable()
    {
        car_AI_Object_Auto.enabled = false;
        car_AI_Object_Auto_1.enabled = false;
    }
    private void OnTriggerEnter(Collider collisionObject)
    {
        if (index > 30)
        {
            index = 0;
        }
        else
        {
            if (collisionObject.tag == "AI_Car_1")
            {
                index += 1;
                pointReference.transform.position = wayPoints_for_AI[index].transform.position;
                //print(wayPoints_for_AI[index].name);
            }
            if (index > 30)
                index = 0;
        }
    }
}
