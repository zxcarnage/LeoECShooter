using Client.Components;
using Leopotam.Ecs;

namespace Systems
{
    public class WeaponShootSystem : IEcsRunSystem
    {
        private EcsFilter<WeaponComponent, ShootComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var weapon = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);
                entity.Del<ShootComponent>();

                if (weapon.CurrentAmmo > 0)
                {
                    weapon.CurrentAmmo--;
                    ref var spawnProjectile = ref entity.Get<SpawnProjectileComponent>();
                }
                else
                {
                    ref var reload = ref entity.Get<TryReloadComponent>();
                }
            }
        }
    }
}