using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.VR.WSA.Input;

public class TapToSelect : MonoBehaviour, IInputClickHandler
{
    public Transform inputEngine;

    Engine engine;    
    bool scanning = false;
    GestureRecognizer recognizer;

    void Start()
    {
        engine = inputEngine.GetComponent<Engine>();
        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            if (!scanning)
            {
                engine.OnScan();
                scanning = true;
            }
            else
            {
                engine.OnReset();
                scanning = false;
            }
        };
        recognizer.StartCapturingGestures();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        // A Click happened here, do something about it
        if (!scanning)
        {
            engine.OnScan();
            scanning = true;
        }
        else
        {
            engine.OnReset();
            scanning = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

