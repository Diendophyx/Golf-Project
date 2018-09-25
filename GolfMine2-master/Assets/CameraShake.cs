using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake (float duration, float magnitude)
    {
        //Stores where the camera's position was when the shake starts
        Vector3 startPos = transform.localPosition;
        float startForce = magnitude; //The starting force is what the magnitude later will be multiplied by
        float smoothing; //Attempts to minimise snapping at the end of the animation

        //This senction smoothes the animation by the duration unless it's below 1, then it usess 1 as the smoothing value
        if (duration < 1f)
        {
            smoothing = startForce / duration;
        }
        else
        {
            smoothing = startForce / 1f;
        }

        //Keeps track of the duration
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            //Generate random shake values up to the magnitude...
            float x = Random.Range(-magnitude, magnitude) * startForce;
            float y = Random.Range(-magnitude, magnitude) * startForce;

            transform.localPosition = new Vector3(x, y, startPos.z); //Move the camera...

            elapsedTime += Time.deltaTime; //Increase the time...

            magnitude = startForce / elapsedTime - smoothing; //Apply smoothing
            
            //When the magnitude reaches the 0 mark
            if (magnitude < 0)
            {
                //Stop the animation from going on any longer than it needs to
                elapsedTime = duration;
                magnitude = 0;
            }

            Debug.Log(elapsedTime + " | " + magnitude);

            yield return null;
        }

        //Put the camera back where it started
        transform.localPosition = startPos;
    }
}
