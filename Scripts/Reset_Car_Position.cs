using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class Reset_Car_Position : MonoBehaviour
{
    private float playerCar_Speed;
    public Transform[] resetPoints;
    public GameObject myCar;
    CarController Ai_Car_Reference;
    public GameObject cameraObject;

    private KeywordRecognizer Input_Recognizer_Reset;
    private Dictionary<string, Action> ResetCommand = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        //Ai_Car_Reference=myCar.GetComponent<CarController>();
        if(myCar.name == "Car")
        {
            ResetCommand.Add("Reset", ResetLocation);
            Input_Recognizer_Reset = new KeywordRecognizer(ResetCommand.Keys.ToArray());
            Input_Recognizer_Reset.OnPhraseRecognized += RecognizedSpeech;
            Input_Recognizer_Reset.Start();
        }
    }
    // Update is called once per frame
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        ResetCommand[speech.text].Invoke();
    }
    void Update()
    {
        if (myCar.name == "CarWaypointBased")
        {
            playerCar_Speed = myCar.GetComponent<CarController>().CurrentSpeed;
            if (playerCar_Speed < 0.5)
                Reset_Car();
        }
        else
        { 
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (playerCar_Speed < 0.1)
                {
                    Reset_Car();
                }
            }
        }
    }
    void Reset_Car()
    {
        Vector3 current_Vehicle_Position = myCar.transform.position;
        Vector3 closestTransform_Position = new Vector3(0f, 0f, 0f);
        float rotation_X = 0f;
        float rotation_Y = 0f;
        float rotation_Z = 0f;

        float closestDistance = 9999999999;

        foreach (Transform resetlocation in resetPoints)
        {
            float currentDistance = Vector3.Distance(current_Vehicle_Position, resetlocation.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestTransform_Position = resetlocation.position;
                rotation_X = resetlocation.rotation.x;
                rotation_Y = resetlocation.rotation.y;
                rotation_Z = resetlocation.rotation.z;
            }
        }
        myCar.transform.position = closestTransform_Position;
        myCar.transform.rotation = Quaternion.Euler(0, cameraObject.transform.eulerAngles.y, 0);

    }
    void ResetLocation()
    {
        if (myCar.name == "Car")
        {
            playerCar_Speed = myCar.GetComponent<CarController>().CurrentSpeed;
            //print("The Ai Car speed: " + playerCar_Speed);
            if (playerCar_Speed < 0.5)
                Reset_Car();
        }
    }
}
   