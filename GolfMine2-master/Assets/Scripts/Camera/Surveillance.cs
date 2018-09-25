using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surveillance : MonoBehaviour
{
    public Camera[] cameras; //Collection of cameras
    public GameObject cameraParent;
    public KeyCode prevKey = KeyCode.Q; //switch back to previous cam
    public KeyCode nextKey = KeyCode.E; //switch back to next cam

    private int camIndex; //Stores which camera
    private int camMax; //Amount of cameras
    private Camera current; //current camera

    // Use this for initialization
    void Start()
    {
        cameras = this.GetComponentsInChildren<Camera>();
        camMax = cameras.Length - 1;
        ActivateCamera(camIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(nextKey))
        {
            camIndex += 1;
            if (camIndex > camMax)
            {
                camIndex = 0;
            }
            ActivateCamera(camIndex);
        } 
        else if (Input.GetKeyDown(prevKey))
        {
            camIndex -= 1;
            if (camIndex < 0)
            {
                camIndex = camMax;
            }
            ActivateCamera(camIndex);
        }
    }

    void ActivateCamera (int camIndex)
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            Camera cam = cameras[i];
            if (i == camIndex)
            {
                cam.gameObject.SetActive(true);
            }
            else
            {
                cam.gameObject.SetActive(false);
            }
        }
    }
}
