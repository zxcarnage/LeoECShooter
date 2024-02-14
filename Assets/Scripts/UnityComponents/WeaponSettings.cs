using UnityEngine;

namespace Client
{
    public class WeaponSettings : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _projectileSocket;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float _projectileRadius;
        [SerializeField] private float _weaponDamage;
        [SerializeField] private int _currentInMagazine;
        [SerializeField] private int _maxInMagazine;
        [SerializeField] private int _totalAmmo;

        public GameObject BulletPrefab => _bulletPrefab;
        public Transform ProjectileSocket => _projectileSocket;
        public float ProjectileSpeed => _projectileSpeed;
        public float WeaponDamage => _weaponDamage;
        public float ProjectileRadius => _projectileRadius;
        public int CurrentInMagazine => _currentInMagazine;
        public int MaxInMagazine => _maxInMagazine;
        public int TotalAmmo => _totalAmmo;
    }
}