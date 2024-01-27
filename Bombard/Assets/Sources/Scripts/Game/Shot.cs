using DG.Tweening;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Spawner))]
    public class Shot : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosion;
        [SerializeField] private Transform _gun;

        private float _dalay = 0.3f;

        private Spawner _spawner;

        private void Awake()
        {
            _spawner = GetComponent<Spawner>();
        }

        private void OnEnable()
        {
            _spawner.Shooted += OnShoot;
        }

        private void OnDisable()
        {
            _spawner.Shooted -= OnShoot;
        }

        private void OnShoot()
        {
            _explosion.Play();
            Vector3 toRotate = new Vector3(0, 0, -4f);
            _gun.DOLocalRotate(toRotate, _dalay).SetLoops(2, LoopType.Yoyo);
        }
    }
}
