using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class SpawnProjectileSystem : IEcsRunSystem
    {
        private EcsFilter<WeaponComponent, SpawnProjectileComponent> _filter;
        private EcsWorld _ecsWorld;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var weapon = _filter.Get1(i);

                var projectileInstantiated =
                    Object.Instantiate(weapon.ProjectilePrefab, weapon.ProjectileSocket.position, Quaternion.identity);
                var projectileEntity = _ecsWorld.NewEntity();

                ref var projectile = ref projectileEntity.Get<ProjectileComponent>();
                projectile.Damage = weapon.WeaponDamage;
                projectile.Direction = weapon.ProjectileSocket.forward;
                projectile.Speed = weapon.ProjectileSpeed;
                projectile.ProjectileInstantiated = projectileInstantiated;
                projectile.PreviousPosition = projectileInstantiated.transform.position;
                projectile.ProjectileRadius = weapon.ProjectileRadius;

                ref var entity = ref _filter.GetEntity(i);
                entity.Del<SpawnProjectileComponent>();
            }
        }
    }
}