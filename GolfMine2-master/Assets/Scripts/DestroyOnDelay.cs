using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDelay : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject.Destroy(this.gameObject, 3);
    }
}
