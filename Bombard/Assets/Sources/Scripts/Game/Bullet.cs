using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _maxDistance;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        Die();
    }

    private void Die()
    {
        Vector3 position = transform.position;
        position.y = Mathf.Abs(position.y);

        float totalDistance = Vector3.Distance(transform.position, position);


        if (totalDistance <= _maxDistance)
        {
            gameObject.SetActive(false);
            Debug.Log("Объект " + transform.name + " находится на расстоянии " + totalDistance + " юнитов");
        }      
    }
}
