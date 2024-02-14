using Leopotam.Ecs;
using UnityEngine;

namespace Client.Components
{
    public struct WeaponComponent
    {
        public EcsEntity Owner;
        public GameObject ProjectilePrefab;
        public Transform ProjectileSocket;
        public float ProjectileSpeed;
        public int TotalAmmo;
        public float ProjectileRadius;
        public float WeaponDamage;
        public int CurrentAmmo;
        public int MaxAmmo;
    }
}