using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class InGameRoot : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        [SerializeField] private PlayerBehaviour _player;
        [SerializeField] private EnemySpawner _spawner;
        [SerializeField] private Text _time;
        [SerializeField] private Text _score;
        
        
        
        

        public void Activate()
        {
            _root.SetActive(true);
            _player.StartMoving();
            _spawner.StartSpawning();
        }

        public void Deactivate()
        {
            _player.EndGame();
            _spawner.EndGame();
            _root.SetActive(false);
        }


        public void SetTime(float currentElapsedTime)
        {
            _time.text = currentElapsedTime.ToString("N1");
            _score.text = ScoreManager.Instance.GetCurrentScore().ToString();
        }
    }
}