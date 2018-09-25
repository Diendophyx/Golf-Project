using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindSpeed : MonoBehaviour
{
    public Text windText;
    public float jesusRocks;
    // Use this for initialization
    void Start()
    {
        NewWind();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            NewWind();
        }
    }

    void NewWind()
    {
        jesusRocks = Random.Range(-100.0f, 100.0f);

        string outputText = "";
        if (jesusRocks < 0)
        {
            outputText = "< " + Mathf.Abs(jesusRocks).ToString("00.00");
        }
        else
        {
            outputText = "> " + Mathf.Abs(jesusRocks).ToString("00.00");
        }

        windText.text = outputText;
    }
}
