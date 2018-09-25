using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Par : MonoBehaviour
{
    public int currentPar;
    public int mapPar;
    public GameObject player;

    public Text mapParText;
    public Text currentParText;

    public bool levelCleared = false;

    public GameObject endScreen;
    public Text didIt;

    RigidCharacterMovement movement;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        movement = player.GetComponent<RigidCharacterMovement>();

        endScreen = GameObject.Find("EndScreen");
        didIt = GameObject.Find("DidItIn").GetComponent<Text>();
        endScreen.SetActive(false);

        currentPar = 1;

        mapParText.text = "Par: " + mapPar;
        currentParText.text = "" + currentPar;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && movement.enabled == true)
        {
            if (currentPar >= mapPar + 2)
            {
                Debug.Log("You Lose!");
                movement.enabled = false;
            }
        }

        if (levelCleared)
        {
            endScreen.SetActive(true);
            if (currentPar == 1)
            {
                didIt.text = "and you did it in a single shot!";
            }
            else
            {
                didIt.text = "and you did it in " + (currentPar - 1) + " shots!";
            }
        }
    }

    public void UpdatePar()
    {
        currentPar += 1;
        currentParText.text = "" + currentPar;
    }
}
