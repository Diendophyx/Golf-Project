using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; //target for the camera
    public bool hideCursor = true; //is cursor hidden
    [Header("Orbit")]
    public Vector3 offset = new Vector3(0, 5f, 0);
    public float xSpeed = 120f; //x axis orbit speed
    public float ySpeed = 120f; //y axis orbit speed
    public float yMin = -20f; //lowest the camera can view
    public float yMax = 80f; //highest the camera can view
    public float distanceMin = 0.5f; //closest distance to player
    public float distanceMax = 15f; //furthest distance from player
    [Header("Collision")]
    public bool cameraCollision = true; //collision enabled
    public float cameraRadius = 0.3f; //radius of collision spherecast
    public LayerMask ignoreLayers; //layers ignored by collision

    private Vector3 originalOffset; //original offset at game start
    private float distance; //current distance to camera
    public float rayDistance = 1000f; //distance for checking for collisions
    private float x = 0f; //x rotation
    private float y = 0f; //y rotation

    // Use this for initialization
    void Start()
    {
        transform.SetParent(null);

        if(hideCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        originalOffset = transform.position - target.position;

        rayDistance = originalOffset.magnitude;

        Vector3 angles = transform.eulerAngles;

        x = angles.y;
        y = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleCursorOnPause();
        }

        if (hideCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;

            y = ClampAngle(y, yMin, yMax);

            transform.rotation = Quaternion.Euler(y, x, 0);
        }
    }

    void FixedUpdate()
    {
        if(target)
        {
            if(cameraCollision)
            {
                Ray camRay = new Ray(target.position, -transform.forward);
                RaycastHit hit;

                if(Physics.SphereCast(camRay, cameraRadius, out hit, rayDistance, ~ignoreLayers, QueryTriggerInteraction.Ignore))
                {
                    distance = hit.distance;
                    return;
                }
            }
            distance = originalOffset.magnitude;
        }
    }

    void LateUpdate()
    {
        if (target)
        {
            Vector3 localOffset = transform.TransformDirection(offset);
            transform.position = (target.position + localOffset) + -transform.forward * distance;
        }
    }

    //Clamps -360 to 360 degrees
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -180f)
        {
            angle += 180;
        }
        if (angle > 180f)
        {
            angle -= 180;
        }

        return Mathf.Clamp(angle, min, max);
    }

    void ToggleCursorOnPause()
    {

        if (hideCursor)
        {
            hideCursor = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            hideCursor = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
