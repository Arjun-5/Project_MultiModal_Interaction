using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enable_FrontCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera front_Camera;
    void Start()
    {
        front_Camera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            front_Camera.enabled = true;

        if (Input.GetKeyUp(KeyCode.F))
            front_Camera.enabled = false;
    }
}
