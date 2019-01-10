using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public GameObject gameLight;
    public Text powerText;
    float startIntensity = 2.0f;
    float reduceIntensity = 0.1f;
    float percentagePower = 100;
    // Start is called before the first frame update
    //bool MicIn;

    void ReduceLight()
    {
        gameLight.GetComponent<Light>().intensity = gameLight.GetComponent<Light>().intensity - reduceIntensity;
    }

    void Start()
    {
        gameLight.GetComponent<Light>().intensity = startIntensity;
        InvokeRepeating("ReduceLight", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        percentagePower = Mathf.Round(gameLight.GetComponent<Light>().intensity / startIntensity * 100);
        powerText.text = percentagePower+"%";
    }
}
