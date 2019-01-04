using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicInput : MonoBehaviour
{
    public Text loudText;
    public Text TutorialFlash;
    public float MicLoudness;
    AudioClip microphoneInput;
    bool microphoneInitialized;
    public float sensitivity = 0.7f;
    public bool flapped;

    public GameObject flashPower;

    private void Flap()
    {
        if(flashPower.GetComponent<Light>().intensity<=1.9f)
        flashPower.GetComponent<Light>().intensity = flashPower.GetComponent<Light>().intensity + 0.1f;
    }

    private void Start()
    {
        //init microphone input
        if (Microphone.devices.Length > 0)
        {
            microphoneInput = Microphone.Start(Microphone.devices[0], true, 999, 44100);
            microphoneInitialized = true;
        }
    }

    private void Update()
    {
        int dec = 128;
        float[] waveData = new float[dec];
        int micPosition = Microphone.GetPosition(null) - (dec + 1); // null means the first microphone
        microphoneInput.GetData(waveData, micPosition);

        // Getting a peak on the last 128 samples
        float levelMax = 0;
        for (int i = 0; i < dec; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        float level = Mathf.Sqrt(Mathf.Sqrt(levelMax));
        if (level > sensitivity) //&& !flapped
        {
            Flap();
            //flapped = true;
            TutorialFlash.gameObject.SetActive(false);

        }
        if (microphoneInitialized)
        {
            if (level < sensitivity)
            {
                loudText.text = level.ToString();
            }
        }
        else
        {
            loudText.text = "";
        }
    }

}
