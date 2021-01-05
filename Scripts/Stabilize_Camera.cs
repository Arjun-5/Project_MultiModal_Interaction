using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabilize_Camera : MonoBehaviour
{
    public GameObject Car_Object;
    public float car_Object_X;
    public float car_Object_Y;
    public float car_Object_Z;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        car_Object_X = Car_Object.transform.eulerAngles.x;
        car_Object_Y = Car_Object.transform.eulerAngles.y;
        car_Object_Z = Car_Object.transform.eulerAngles.z;

        transform.eulerAngles = new Vector3(car_Object_X - car_Object_X, car_Object_Y, car_Object_Z - car_Object_Z);
    }
}
