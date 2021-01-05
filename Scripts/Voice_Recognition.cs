using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityStandardAssets.CrossPlatformInput;

public class Voice_Recognition : MonoBehaviour
{
    private KeywordRecognizer Input_Recognizer,fusion_Recognizer;
    private Dictionary<string, Action> keyValuePairs = new Dictionary<string, Action>();

    public AudioClip car_Horn_main;
    public AudioSource Sound_Source_main;

    public AudioClip music_main;
    public AudioSource music_Source_main;

    private void Start(){

        Sound_Source_main.clip = car_Horn_main;
        music_Source_main.clip = music_main;

        keyValuePairs.Add("Start", Start_Driving);
        keyValuePairs.Add("Stop", Stop_Driving);
        keyValuePairs.Add("Music", play_Music);       
        keyValuePairs.Add("StopMusic", stop_Music);
        keyValuePairs.Add("Honk", play_Audio);
        

        Input_Recognizer = new KeywordRecognizer(keyValuePairs.Keys.ToArray());
        Input_Recognizer.OnPhraseRecognized += RecognizedSpeech;
        Input_Recognizer.Start(); 
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        keyValuePairs[speech.text].Invoke();
    }
    
    private void Start_Driving()
    {
        transform.Translate(10,0,0);
    }
    private void Stop_Driving()
    {
        transform.Translate(0, 0, 0);
    }
    private void play_Audio()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sound_Source_main.Play();
        }       
    }
    private void play_Music()
    {
        music_Source_main.Play();
    }
    private void stop_Music()
    {
        music_Source_main.Stop();
    }
}
