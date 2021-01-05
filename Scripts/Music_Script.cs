using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Script : MonoBehaviour
{
    public AudioClip music;
    public AudioSource music_Source;
    // Start is called before the first frame update
    void Start()
    {
        music_Source.clip = music;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            music_Source.Play();
        else if(Input.GetKeyUp(KeyCode.P))
            music_Source.Stop();
        if (Input.GetKeyDown(KeyCode.O))
            music_Source.Stop();
    }
}
