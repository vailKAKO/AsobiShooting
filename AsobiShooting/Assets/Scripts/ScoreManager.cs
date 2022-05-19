using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;

        [SerializeField] private Text _text;

        private int _score = 0;

        private void Awake()
        {
            Instance = this;
        }

        public void InitializeScore()
        {
            _score = 0;
        }

        public void ChangeText()
        {
            _text.text = _score.ToString();
        }

        public void ChangeScore(int forceeee)
        {
            _score += forceeee;
        }

        public int GetCurrentScore()
        {
            return _score;
        }
    }
}