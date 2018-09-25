using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShake : MonoBehaviour
{
    public ParticleSystem explosion; //The ParticleSystem component of the explosion object
    public CameraShake cameraShake; //The CameraShake component of the camera

    public float shakeDuration; //Duration of the camera shake
    public float shakeForce; //How forceful the shake is

    void Update()
    {        
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //Need to get the explosion from ingame somewhere, probably with a Find thing
        //    explosion.Play();
        //    StartShake(shakeDuration, shakeForce);
        //}
    }

    public void StartShake(float duration, float force)
    {
        //This line changes the force based on the distance the camera is from the explosion
        //Further away, less force
        float finalForce = force / Vector3.Distance(explosion.transform.position, cameraShake.transform.position);

        StartCoroutine(cameraShake.Shake(duration, finalForce)); //Start the shake on the camera
    }
}
