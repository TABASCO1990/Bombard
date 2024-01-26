using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _secondBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_bulletPrefab);       
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _secondBetweenSpawn)
        {
            if(TryGetObject(out GameObject bullet))
            {
                _elapsedTime = 0;
                SetBullet(bullet, _spawnPoint.position);
            }
        }
    }

    private void SetBullet(GameObject bullet, Vector3 spawnPoint)
    {
        bullet.SetActive(true);
        bullet.transform.position = spawnPoint;
    }
}
