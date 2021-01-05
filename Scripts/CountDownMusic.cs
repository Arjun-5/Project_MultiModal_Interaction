using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
public class CountDownMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource getReady;
    public AudioSource Go_Play;
    public GameObject countDown_UI;
    public GameObject carControls;
    public GameObject AICar;
    CarController car_Object;
    CarController car_AI_Object;
    void Start()
    {
        car_Object = carControls.GetComponent<CarController>();
        car_AI_Object = AICar.GetComponent<CarController>();
        StartCoroutine(gameStart());       
    }
    IEnumerator gameStart()
    {
        countDown_UI.GetComponent<Text>().text = "3";
        getReady.Play();
        countDown_UI.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown_UI.SetActive(false);
        countDown_UI.GetComponent<Text>().text = "2";
        getReady.Play();
        countDown_UI.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown_UI.SetActive(false);
        countDown_UI.GetComponent<Text>().text = "1";
        getReady.Play();
        countDown_UI.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown_UI.SetActive(false);
        countDown_UI.GetComponent<Text>().text = "Start";
        Go_Play.Play();
        countDown_UI.SetActive(true);
        yield return new WaitForSeconds(1);
        countDown_UI.SetActive(false);
        car_Object.enabled = true;
        car_AI_Object.enabled = true;
    }
}
