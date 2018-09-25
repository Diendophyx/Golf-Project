using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraStuff : MonoBehaviour
{
    LookAtProjectile projectileCamera;
    Par par;
    public GameObject mainCamera;
    public GameObject crossHair;

    bool updated = true;
    void Start()
    {
        crossHair = GameObject.Find("CrossHair");

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        par = this.GetComponent<Par>();

        projectileCamera = GameObject.Find("ShotCamera").GetComponent<LookAtProjectile>();
        projectileCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (projectileCamera.target == null)
        {
            if (updated == false)
            {
                par.UpdatePar();
                updated = true;
            }

            projectileCamera.enabled = false;
            mainCamera.SetActive(true);
            crossHair.SetActive(true);
        }
        else
        {
            updated = false;
            mainCamera.SetActive(false);
            crossHair.SetActive(false);
        }
    }
}
