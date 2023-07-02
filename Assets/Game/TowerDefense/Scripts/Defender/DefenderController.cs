using System;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.TowerDefense.Scripts.Defender
{
    public class DefenderController : MonoBehaviour
    {
        private Transform _target;
        private Vector3 _targetDirection;
        private Quaternion _targetRotation;
        [SerializeField] private float _turnSpeed = 5.0f;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _muzzle;
        [SerializeField] private float _weaponInitialSpeed = 1.0f;
        private Transform _bulletCaches;
        private float _lastTimeAttack = 0.0f;
        [SerializeField] private float _attackCooldown = 0.5f;
        private float _speedCoef = 1000;

        // Start is called before the first frame update
        void Start()
        {
            _bulletCaches = GameObject.FindGameObjectWithTag("BulletCaches").transform;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            // If no target do nothing
            if (_target is null) return; // if (!_target)
            TurnToLookAtTarget();
            if (CoolingDown()) return;
            AttackToTarget();
        }

        private bool CoolingDown()
        {
            return Time.time < _lastTimeAttack + _attackCooldown;
        }

        private void AttackToTarget()
        {
            _lastTimeAttack = Time.time;
            var bullet = Instantiate(_bulletPrefab, _muzzle.position, quaternion.identity);
            bullet.transform.SetParent(_bulletCaches);
            if (bullet.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.velocity = _speedCoef * _weaponInitialSpeed * Time.fixedDeltaTime * _targetDirection;
            }
            
            Destroy(bullet, 2.0f);
        }

        private void TurnToLookAtTarget()
        {
            _targetDirection = (_target.position - transform.position).normalized;
            _targetRotation = Quaternion.LookRotation(-_targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, Time.fixedDeltaTime * _turnSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Attacker"))
            {
                _target = other.transform;
            }
        }
    }
}
