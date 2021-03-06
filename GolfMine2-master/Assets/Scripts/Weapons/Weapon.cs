﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Task 1:  Draw.io projectile system
 *          Needs the following structure: 
 *              Projectile
 *              /   |   \
 *          Normal Fire Explosive
 *          Variables and functions for each class
 *          
 *############################################################################ 
 * 
 * Task 2:  Ensure the player can't shoot until the weapon is
 *          ready to be fired (fire rate)
 *          Refer to #game-systems-j211 for resources for this task
 *          
 */

namespace GameSystems
{
    public abstract class Weapon : MonoBehaviour
    {
        #region OldCode
        //public GameObject bullet;
        //public Transform spawnPoint;

        //// Use this for initialization
        //void Start()
        //{

        //}


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
        public int damage = 100;
        public int ammo = 30;
        public float accuracy = 1f;
        public float range = 10f;
        public float rateOfFire = 5f;
        public GameObject projectile;
        public Transform spawnPoint;

        protected int currentAmmo = 0;

        public abstract void Attack(float power);

        public virtual void Reload()
        {
            currentAmmo = ammo;
        }
    }
}
