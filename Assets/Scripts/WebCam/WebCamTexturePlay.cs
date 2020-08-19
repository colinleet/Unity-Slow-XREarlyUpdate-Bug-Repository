using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WebCamTexturePlay : MonoBehaviour {

    [Tooltip("Turns on rendering the webcam to the renderer's texture.")]
    public bool UseWebcam = true;

    /// <summary>
    /// Texture for the webcam data to be saved to.
    /// </summary>
    private WebCamTexture webcamTexture;

    void Start() {
        if ( !UseWebcam ) return;

        // Get all devices
        WebCamDevice[] devices = WebCamTexture.devices;

        // Get first devices's name
        if ( devices.Length == 0 ) {
            Debug.LogWarning("No webcam is connected.");
            return;
        }

        // Set the device to 
        string deviceName = devices[0].name;

        // Assign webcam texture to renderer
        webcamTexture = new WebCamTexture();
        webcamTexture.deviceName = deviceName;

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetTexture("_BaseColorMap", webcamTexture);
        //renderer.material.mainTexture = webcamTexture;

        // Get stream playing
        webcamTexture.Play();
    }

    /// <summary>
    /// Logs all of the avaiable webcames.
    /// </summary>
    public void LogAllDevices() {
        WebCamDevice[] devices = WebCamTexture.devices;
        for ( int i = 0; i < devices.Length; i++ )
            Debug.Log(devices[i].name);
    }
}
