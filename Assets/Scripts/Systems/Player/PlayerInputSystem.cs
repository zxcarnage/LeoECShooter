using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputData, HasWeaponComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var input = ref _filter.Get1(i);

                var horizontal = Input.GetAxis("Horizontal");
                var vertical = Input.GetAxis("Vertical");

                input.MoveInput = new Vector3(horizontal, 0, vertical);
                input.ShootInput = Input.GetMouseButton(0);
                TryReload(i);
            }
        }

        private void TryReload(int counter)
        {
            ref var hasWeapon = ref _filter.Get2(counter);
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                ref var weapon = ref hasWeapon.Weapon.Get<WeaponComponent>();

                if (weapon.CurrentAmmo < weapon.MaxAmmo)
                {
                    Reload(counter);
                }
            }
        }

        private void Reload(int counter)
        {
            ref var entity = ref _filter.GetEntity(counter);
            entity.Get<TryReloadComponent>();
        }
    }
}