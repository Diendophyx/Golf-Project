using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrisbeeMine : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rigid;

    public GameObject mapController;
    public WindSpeed wind;

    public GameObject player;
    Transform playerLocal;

    LookAtProjectile projectileCamera;
    Par par;


    public float windSpeed;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerLocal = player.GetComponent<Transform>();

        rigid = GetComponent<Rigidbody>();
        mapController = GameObject.Find("MapController");
        wind = mapController.GetComponent<WindSpeed>();
        par = mapController.GetComponent<Par>();

        projectileCamera = GameObject.Find("ShotCamera").GetComponent<LookAtProjectile>();

        //Debug.Log(wind.jesusRocks);
    }

    public void Fire(Vector3 direction)
    {
        //Debug.Log(wind.jesusRocks);
        rigid.AddForce(direction * speed, ForceMode.Impulse);
        //Vector3 windChange = new Vector3(direction.x * wind.windSpeed, direction.y * speed, direction.z * speed);
        //rigid.AddForce(windChange, ForceMode.Impulse);
    }

    private void Update()
    {
        windSpeed = wind.jesusRocks / 10f;
        Vector3 windDirection = new Vector3(1, 0, 0);

        rigid.AddForce(windDirection * windSpeed, ForceMode.Force);

        if (transform.position.y < -10)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        //Debug.Log(rigid.velocity.magnitude + ":" + windSpeed);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Target")
        {
            playerLocal.position = transform.position;

            par.levelCleared = true;
            Debug.Log("You Win!");
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), player.GetComponent<Collider>());
        }

        if (col.gameObject.tag == "Ground")
        {
            if (rigid.velocity.magnitude <= windSpeed || rigid.velocity.magnitude <= (windSpeed * -1))
            {
                Debug.Log("Landed");
                playerLocal.position = transform.position;
                GameObject.Destroy(this.gameObject);
                projectileCamera.enabled = false;
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Enemy enemy = other.GetComponent<Enemy>();
    //    if (enemy)
    //    {
    //        enemy.DealDamage(damage);
    //        Destroy(gameObject);
    //    }
    //}
}
