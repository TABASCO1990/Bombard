using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _distance = 20;

    private Ray _ray;

    private void Start()
    {
        _ray = new Ray(transform.position, transform.forward);
        var hitInfo = Physics.Raycast(_ray.origin, _ray.direction, _distance);
        print(hitInfo);
    }
}
