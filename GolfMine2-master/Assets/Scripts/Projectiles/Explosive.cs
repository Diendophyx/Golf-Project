using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float radius = 5f;
    public float armTime;
    public int radiusDamage;
    public float knockBack;
    public float explosionForce = 50f;
    public ParticleSystem explosionEffect;
    public GameObject wall;

    //public TriggerShake shake;
    //public CameraShake camera;

    //void Start()
    //{
    //    shake = GameObject.Find("Handler").GetComponent<TriggerShake>();
    //    camera = GameObject.Find("ShotCamera").GetComponent<CameraShake>();
    //}

    public void OnCollisionEnter(Collision collision)
    {
        Object other = collision.collider.GetComponent<Rigidbody>();
        if (other)
        {
            Explode();
            ExplosionEffect();
        }
    }
    public void Explode()
    {
 
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {

            Rigidbody rBody = nearbyObject.GetComponent<Rigidbody>();
            if (rBody != null && rBody.gameObject.tag != "Player")
            {
                rBody.isKinematic = false;
                rBody.AddExplosionForce(explosionForce, transform.position, 5, 5, ForceMode.Impulse);
                Destroy(gameObject, 2);

            }
        }
    }
    public void ExplosionEffect()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        //shake.cameraShake = camera;
        //shake.explosion = explosionEffect;
        //shake.StartShake(2.0f, 4.0f);
        Destroy(explosionEffect, 5);
    }
}
