using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Props")] [SerializeField] private Vector2 _bulletDirection = Vector2.up;

    [SerializeField] private float _shotInterval = 0.05f;
    [Header("Prefs")] [SerializeField] private Bullet _bulletPrefab;

    private float _currentElapsedTime = 0f;

    private Transform _transform;


    private bool _isInGame = false;
    public Transform GetTransform => _transform;

    private void Start()
    {
        _transform = transform;
    }

    public void StartMoving()
    {
        _isInGame = true;
        StartCoroutine(nameof(Move));
    }

    public void EndGame()
    {
        _isInGame = false;
    }

    private IEnumerator Move()
    {
        while (_isInGame)
        {
            yield return null;
            _currentElapsedTime += Time.deltaTime;
            _transform.position = Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x,Input.mousePosition.y,10));
            if (_currentElapsedTime > _shotInterval)
            {
                if (Input.GetMouseButton(0))
                {
                    _currentElapsedTime = 0;
                    var t = Instantiate(_bulletPrefab);
                    t.transform.position = _transform.position;
                    t.InitializeBulletAndMove(_bulletDirection);
                }
            }
            
        }
        
    }
}