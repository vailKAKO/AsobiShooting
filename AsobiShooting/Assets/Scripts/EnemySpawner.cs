using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private Enemy _enemyPrefab;

        [SerializeField] private PlayerBehaviour _player;
        
        [Header("Props")]
        [SerializeField] private float _spawnIntervalBase = 0.4f;

        [SerializeField] private float _spawnIntervalRange = 0.1f;


        private bool _isInGame = false;

        private List<Enemy> _existEnemies = new List<Enemy>();

        private float _currentElapsedTime = 0f;
        private float _currentSpawnInterval = 0;

        public void StartSpawning()
        {
            _isInGame = true;
            StartCoroutine(nameof(Spawn));
        }

        public void EndGame()
        {
            _isInGame = false;
        }

        private IEnumerator Spawn()
        {
            _currentSpawnInterval = GetSpawnInterval();
            while (_isInGame)
            {
                yield return null;
                _currentElapsedTime += Time.deltaTime;
                if (_currentElapsedTime > _currentSpawnInterval)
                {
                    _currentElapsedTime = 0;
                    
                    _currentSpawnInterval = GetSpawnInterval(); //Setでよくない?しらんけど
                    var t = Instantiate(_enemyPrefab);
                    t.InitializeEnemy(_player.GetTransform);
                    _existEnemies.Add(t);
                }
            }

            foreach (var existEnemy in _existEnemies)
            {
                if(existEnemy!=null) existEnemy.EndGame();
            }
            
            _existEnemies.Clear();
        }

        private float GetSpawnInterval()
        {
            return _spawnIntervalBase + Random.Range(_spawnIntervalRange, _spawnIntervalRange);
        }

    }
}