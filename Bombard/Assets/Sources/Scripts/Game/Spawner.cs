using UnityEngine;
using UnityEngine.UIElements;

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
        _spawnPoint = transform;

        _elapsedTime += Time.deltaTime;

        if(_elapsedTime > _secondBetweenSpawn)
        {
            if(TryGetObject(out GameObject bullet))
            {
                _elapsedTime = 0;
                SetBullet(bullet, _spawnPoint.position, _spawnPoint.rotation);                
            }
        }  
    }

    private void SetBullet(GameObject bullet, Vector3 spawnPoint, Quaternion rotate)
    {
        bullet.SetActive(true);
        bullet.transform.position = spawnPoint;
        bullet.transform.rotation = rotate;
    }
}
