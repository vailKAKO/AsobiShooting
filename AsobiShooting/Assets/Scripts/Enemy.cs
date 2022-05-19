using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _velocity = 0.1f;
        [SerializeField] private Vector2 _rightTop;
        [SerializeField] private Vector2 _leftBottom;


        private Transform _transform;

        private bool _isMovable = true;
        private Transform _targetTransform;
        private int _FORCEEEE = 1;

        private void Awake()
        {
            _transform = transform;
        }

        public void InitializeEnemy(Transform targetTransform)
        {
            _transform.position = new Vector2(Random.Range(_rightTop.x, _leftBottom.x),
                Random.Range(_rightTop.y, _leftBottom.y));
            _targetTransform = targetTransform;
            StartCoroutine(nameof(Move));
        }

        //映画みたいだね
        public void EndGame()
        {
            _isMovable = false;
        }

        IEnumerator Move()
        {
            while (_isMovable)
            {
                yield return null;
                var t = (_targetTransform.position - _transform.position);
                _transform.position += t.normalized * _velocity * Time.deltaTime;
            }
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Bullet bullet))
            {
                bullet.OnEnterEnemy();
                ScoreManager.Instance.ChangeScore(_FORCEEEE);
                _isMovable = false;
            }
            else if (other.TryGetComponent(out PlayerBehaviour player))
            {
                ScoreManager.Instance.ChangeScore(-1);
                //  player.OnEnemyEnter(_FORCEEEE);
            }
        }
    }
}