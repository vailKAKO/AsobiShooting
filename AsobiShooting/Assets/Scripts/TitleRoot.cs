using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class TitleRoot : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _root;
        
        public UnityEvent OnButtonDown()
        {
            return _button.onClick;
        }

        public void Activate()
        {
            _root.SetActive(true);
        }

        public void Deactivate()
        {
            _root.SetActive(false);
        }
        
    }
}