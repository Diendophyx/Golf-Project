using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeMeter : MonoBehaviour
{
    RigidCharacterMovement player;
    public Slider chargeMeter;

    // Use this for initialization
    void Start()
    {
        chargeMeter = GameObject.Find("ChargeMeter").GetComponent<Slider>();
        player = GameObject.Find("Player").GetComponent<RigidCharacterMovement>();

        chargeMeter.value = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.charging == true)
        {
            chargeMeter.value = player.power;
        }
        else
        {
            chargeMeter.value = 0f;
        }
    }
}
