using System.Collections;
using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _distance = 20;

        private Vector3 _direction;

        public float Speed
        {
            get => _speed;
            set => _speed = value > 0 ? value : 1f;
        }

        public float Distance
        {
            get => _distance;
            set => _distance = value > 0 ? value : 1f;
        }

        private void Start()
        {
            SetDirection();
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.deltaTime);

            if (gameObject.transform.position.z >= _direction.z)
            {
                _direction = Vector3.zero;
                gameObject.SetActive(false);
            }
        }

        public void SetDirection()
        {
            _direction = transform.position + transform.forward * _distance;
        }
    }
}