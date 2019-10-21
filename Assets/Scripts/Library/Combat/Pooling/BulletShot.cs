﻿using System;
using Library.Combat.Enemy;
using UnityEngine;

namespace Library.Combat.Pooling
{
    public class BulletShot : MonoBehaviour, IGameObjectPooled
    {
        public float moveSpeed = 30f;
        public int damage = 10;
        private float _lifeTime;
        public float maxLifeTime;

        private BulletShotPool _pool;

        public BulletShotPool Pool
        {
            get => _pool;
            set
            {
                if (_pool == null)
                    _pool = value;
                else 
                    throw new Exception("Bad pool use, this should only get set once!");
            }
        }

        private void OnEnable()
        {
            _lifeTime = 0f;
        }

        private void Update()
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.forward);
            _lifeTime += Time.deltaTime;
            if (_lifeTime > maxLifeTime)
            {
                _pool.ReturnToPool(gameObject);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            _pool.ReturnToPool(gameObject);
        }
    }
    
    internal interface IGameObjectPooled
    {
        BulletShotPool Pool { get; set; }
    }
}