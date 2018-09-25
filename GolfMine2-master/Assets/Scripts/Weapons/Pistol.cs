using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

public class Pistol : Weapon
{
    #region Old
    //public GameObject bullet;
    //public Transform spawnPoint;


    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        GameObject clone = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
    //        Bullet newBullet = clone.GetComponent<Bullet>();

    //        newBullet.Fire(transform.forward);
    //    }
    //}
    #endregion
    public float spread;
    public int magSize;

    LookAtProjectile projectileCamera;
    MiniMapMine mineIcon;

    void Start()
    {
        projectileCamera = GameObject.Find("ShotCamera").GetComponent<LookAtProjectile>();
        mineIcon = GameObject.Find("MineIcon").GetComponent<MiniMapMine>();
    }

    public override void Attack(float power)
    {
        GameObject clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        FrisbeeMine newBullet = clone.GetComponent<FrisbeeMine>();

        Vector3 direction = transform.forward * power;
        newBullet.Fire(direction);

        projectileCamera.enabled = true;
        projectileCamera.target = newBullet.GetComponent<Transform>();

        mineIcon.target = newBullet.GetComponent<Transform>();
    }

}
