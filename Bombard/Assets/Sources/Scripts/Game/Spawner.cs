using System;
using UnityEngine;

namespace Game
{
    public class Spawner : ObjectPool
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _secondBetweenSpawn;

        private float _elapsedTime = 0;
        private float _minDalay = 0.1f;

        public event Action Shooted;

        private void Start()
        {
            Initialize(_bulletPrefab);
        }

        private void Update()
        {
            _spawnPoint = transform;

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _secondBetweenSpawn)
            {
                if (TryGetObject(out GameObject bullet))
                {
                    _elapsedTime = 0;
                    SetBullet(bullet, _spawnPoint.position, _spawnPoint.rotation);
                    bullet.GetComponent<Bullet>().SetDirection();
                }
            }
        }

        private void SetBullet(GameObject bullet, Vector3 spawnPoint, Quaternion rotate)
        {
            Shooted?.Invoke();
            bullet.SetActive(true);
            bullet.transform.position = spawnPoint;
            bullet.transform.rotation = rotate;
            
        }

        public void ChangeDelaySpawn(string value)
        {
            float delay;

            if (float.TryParse(value, out delay) && delay >= _minDalay)
                _secondBetweenSpawn = delay;
            else
                _secondBetweenSpawn = 1f;
        }

        public void ChangeSpeed(string value)
        {
            float speed;

            if (float.TryParse(value, out speed))
            {
                foreach (GameObject bullet in _pool)
                {
                    bullet.GetComponent<Bullet>().Speed = speed;
                }
            }
        }

        public void ChangeDistance(string value)
        {
            float distance;

            if (float.TryParse(value, out distance))
            {
                foreach (GameObject bullet in _pool)
                {
                    bullet.GetComponent<Bullet>().Distance = distance;
                }
            }
        }
    }
}