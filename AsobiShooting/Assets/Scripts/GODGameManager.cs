using System;
using DefaultNamespace;
using UnityEngine;


public enum GameState
{
    Title,
    Game,
    Result
}

public class GODGameManager : MonoBehaviour
{

    [SerializeField] private InGameRoot _inGameRoot;
    [SerializeField] private ResultRoot _resultRoot;
    [SerializeField] private TitleRoot _titleRoot;
    [SerializeField] private float _timeSpan = 10;
    

    private GameState _state;
    private float _currentElapsedTime = 0;
    
    private void Start()
    {
        _state = GameState.Title;
        _titleRoot.Activate();
        _inGameRoot.Deactivate();
        _resultRoot.Deactivate();
        ScoreManager.Instance.InitializeScore();

        _titleRoot.OnButtonDown().AddListener(OnTitleButtonDown);
        _resultRoot.OnButtonDown().AddListener(OnResultButtonDown);
    }

    private void Update()
    {
        if (_state != GameState.Game) return;
        _currentElapsedTime += Time.deltaTime;
        _inGameRoot.SetTime(_timeSpan - _currentElapsedTime);
        if (!(_currentElapsedTime > _timeSpan)) return;
        _currentElapsedTime = 0;
        _state = GameState.Result;
        _resultRoot.Activate();
        _inGameRoot.Deactivate();
    }

    private void OnTitleButtonDown()
    {
        _state = GameState.Game;
        _inGameRoot.Activate();
        _titleRoot.Deactivate();
    }

    private void OnResultButtonDown()
    {
        _state = GameState.Title;
        _resultRoot.Deactivate();
        _titleRoot.Activate();
        ScoreManager.Instance.InitializeScore();
    }
    
    
}