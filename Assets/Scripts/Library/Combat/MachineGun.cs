﻿using System;
using Library.Combat.Enemy;
using Library.Events;
using UnityEngine;

namespace Library.Combat
{
    public class MachineGun : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float range;

        [SerializeField] private Camera cam;
        [SerializeField] private GameObject vfx;
        
        public float fireRate;

        private float _fireTimer;
        

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (_fireTimer >= fireRate)
                {
                    _fireTimer = 0;
                    Shoot();
                }
            }
            _fireTimer += Time.deltaTime;
        }

        private void Shoot()
        {
            cam = FindObjectOfType<Camera>();
            RaycastHit hit;
            if (!Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) return;
            
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
            else if (hit.collider.gameObject.CompareTag("Sign"))
            {
                hit.collider.gameObject.GetComponent<SignActivation>().PathSign();
            }
            
            Instantiate(vfx, hit.point, hit.collider.transform.rotation);
        }
    }
}
