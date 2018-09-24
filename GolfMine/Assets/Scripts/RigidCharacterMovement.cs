using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

public class RigidCharacterMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float jumpHeight = 10f;
    public Rigidbody rigid;
    public float rayDistance = 1f;
    
    public Weapon currentWeapon;

    GameObject shootPoint;
    public bool rotateToMainCamera = false;
    public bool weaponRotationThing = false;

    //private bool isGrounded = true;
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //currentWeapon = weapon.GetComponent<Weapon>();
        //shootPoint = weapon.transform.GetChild(0).GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        #region oldCode
        //if (Input.GetKey(KeyCode.W))
        //{
        //    rigid.AddForce(Vector3.forward * playerSpeed);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    rigid.AddForce(Vector3.back);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    rigid.AddForce(Vector3.left * playerSpeed);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    rigid.AddForce(Vector3.right * playerSpeed);
        //}

        //if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        //{
        //    rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //    isGrounded = false;
        //}
        #endregion
        float inputH = Input.GetAxis("Horizontal") * playerSpeed;
        float inputV = Input.GetAxis("Vertical") * playerSpeed;

        Vector3 moveDirection = new Vector3(inputH, 0f, inputV) * playerSpeed;

        Vector3 camEuler = Camera.main.transform.eulerAngles;

        if (rotateToMainCamera)
        {
            moveDirection = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDirection;
        }

        Vector3 force = new Vector3(moveDirection.x, rigid.velocity.y, moveDirection.z);


        if (Input.GetButton("Jump") && IsGrounded()) //Did the player press the Jump button AND are they NOT shwoomked?
        {
            force.y = jumpHeight;
        }

        rigid.velocity = force;

        Quaternion playerRotation = Quaternion.AngleAxis(camEuler.y, Vector3.up);
        transform.rotation = playerRotation;

        if (weaponRotationThing)
        {
            Quaternion weaponRotation = Quaternion.AngleAxis(camEuler.x, Vector3.right);
            currentWeapon.transform.localRotation = weaponRotation;
        }

        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.Attack();
        }

        //if(moveDirection.magnitude > 0)
        //{
        //    transform.rotation = Quaternion.LookRotation(moveDirection);
        //}

    }

    bool IsGrounded()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(groundRay, out hit, rayDistance))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
    }


}
