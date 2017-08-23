using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour, IInputClickHandler {

    public Transform textMeshObject;

    // Use this for initialization
    private void Start()
    {
        this.textMesh = this.textMeshObject.GetComponent<TextMesh>();
        this.OnReset();        
    }
    public void OnScan()
    {
        this.textMesh.text = "scan pendant 30s";

#if !UNITY_EDITOR
    MediaFrameQrProcessing.Wrappers.ZXingQrCodeScanner.ScanFirstCameraForQrCode(
        result =>
        {
          UnityEngine.WSA.Application.InvokeOnAppThread(() =>
          {
            this.textMesh.text = result?.Text ?? "Non trouvé";
          }, 
          false);
        },
        TimeSpan.FromSeconds(30));
#endif
    }
    public void OnReset()
    {
        this.textMesh.text = "Dire 'go' pour commencer !";
    }

    TextMesh textMesh;

    // Update is called once per frame
    void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        this.textMesh.text = "Event catché !";
    }
}
