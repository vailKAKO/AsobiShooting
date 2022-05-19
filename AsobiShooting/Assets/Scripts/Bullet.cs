using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        private Vector2 _direction;

        private Transform _transform;
        private bool _isMovable = false;
        [SerializeField] private float _lifeSpan = 2f;

        private float _currentLifeTime = 0f;

        private void Start()
        {
            _transform = transform;
        }

        public void InitializeBulletAndMove(Vector2 direction)
        {
            _direction = direction;
            _isMovable = true;
            StartCoroutine(nameof(Move));
        }
        
        
        public void EndGame()
        {
            _isMovable = false;
        }

        IEnumerator Move()
        {
            while (_isMovable)
            {
                yield return null;
                _currentLifeTime += Time.deltaTime;
                _transform.position += (Vector3)_direction;
                if (_currentLifeTime > _lifeSpan) _isMovable = false;

            }
            Destroy(this.gameObject);
        }

        public void OnEnterEnemy()
        {
            _isMovable = false;
        }
    }
}