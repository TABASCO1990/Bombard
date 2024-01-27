using UnityEngine;
using UnityEngine.Events;
using Game;
using TMPro;

namespace UI
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] protected Spawner _spawner;
        [SerializeField] protected TMP_InputField _input;

        protected void EnableAction(UnityAction<string> action)
        {
            _input.onValueChanged.AddListener(action);
        }

        protected void DisableAction(UnityAction<string> action)
        {
            _input.onValueChanged.RemoveListener(action);
        }
    }
}
