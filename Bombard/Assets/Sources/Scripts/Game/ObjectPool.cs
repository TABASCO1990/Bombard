using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private int _capacity;

        protected List<GameObject> _pool = new List<GameObject>();

        protected void Initialize(GameObject prefab)
        {
            for (int i = 0; i < _capacity; i++)
            {
                GameObject spawned = Instantiate(prefab, _container.transform);
                spawned.SetActive(false);

                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.First(obj => obj.activeSelf == false);
            result.transform.position = Vector3.zero;
            return result != null;
        }
    }
}
