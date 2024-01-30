using UnityEngine;

namespace RakibJahan
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private float defaultShootDelay = 1f;
        [SerializeField] private int damagePerShootable = 100;
        [SerializeField] private Shootable shootablePrefab;
        [SerializeField] private Transform shootFrom;
        [SerializeField] private int damageAddPerYear = 2;
        private float _shootDelay;
        private float _runningTimer;
        private int _damagePerShootable;
        private int _year = 0;

        private void Start()
        {
            _shootDelay = defaultShootDelay;
            _damagePerShootable = damagePerShootable;
        }

        private void Update()
        {
            _runningTimer += Time.deltaTime;
            if (_runningTimer >= _shootDelay)
            {
                _runningTimer = 0f;
                Shoot();
            }
        }

        public void UpdateWeaponYear(int toAdd)
        {
            _year += toAdd;
            var damageToAdd = _year * damageAddPerYear;
            _damagePerShootable = damagePerShootable + damageToAdd;
        }
        
        public void Shoot()
        {
            Instantiate(shootablePrefab, shootFrom.position, Quaternion.identity).Init(_damagePerShootable);
        }
    }
}