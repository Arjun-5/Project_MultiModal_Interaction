using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Script : MonoBehaviour
{
    public AudioClip car_Horn;
    public AudioSource Sound_Source;
    // Start is called before the first frame update
    void Start()
    {
        Sound_Source.clip = car_Horn;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftShift))
         //   Sound_Source.Play();
    }
}
