using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapMine : MonoBehaviour
{
    public Transform target;
    public Transform me;

    public Vector3 startHeight;
    // Use this for initialization
    void Start()
    {
        me = this.GetComponent<Transform>();
        target = this.GetComponent<Transform>();

        startHeight = me.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            me.transform.position = new Vector3(0, -10, 0);
        }
        else
        {
            Vector3 newPos = new Vector3(target.position.x, startHeight.y, target.position.z);
            me.transform.position = newPos;
        }
    }
}
