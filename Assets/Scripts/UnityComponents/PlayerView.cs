using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class PlayerView : MonoBehaviour
    {
        private EcsEntity _entity;

        public void SetPlayerEntity(EcsEntity entity)
        {
            _entity = entity;
        }

        public void Shoot()
        {
            var hasWepon = _entity.Get<HasWeaponComponent>();
                hasWepon.Weapon.Get<ShootComponent>();
        }

        public void Reload()
        {
            _entity.Get<HasWeaponComponent>().Weapon.Get<ReloadingFinishedComponent>();
        }
    }
}