using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ReloadingSystem : IEcsRunSystem
    {
        private EcsFilter<TryReloadComponent, AnimatorRef>.Exclude<ReloadingComponent> _tryReloadFilter;
        private EcsFilter<WeaponComponent, ReloadingFinishedComponent> _reloadFinishedFilter;
        
        private static readonly int Reload = Animator.StringToHash("Reload");

        public void Run()
        {
            TryReload();
            FinishReload();
        }

        private void TryReload()
        {
            foreach (var i in _tryReloadFilter)
            {
                ref var animatorRef = ref _tryReloadFilter.Get2(i);
                animatorRef.Animator.SetTrigger(Reload);

                ref var entity = ref _tryReloadFilter.GetEntity(i);
                entity.Get<ReloadingComponent>();
            }
        }

        private void FinishReload()
        {
            foreach (var i in _reloadFinishedFilter)
            {
                ref var weapon = ref _reloadFinishedFilter.Get1(i);

                var needAmmo = weapon.MaxAmmo - weapon.CurrentAmmo;

                weapon.CurrentAmmo = needAmmo >= weapon.TotalAmmo
                    ? weapon.TotalAmmo + weapon.CurrentAmmo
                    : weapon.MaxAmmo;

                weapon.TotalAmmo -= needAmmo;
                weapon.TotalAmmo = weapon.TotalAmmo < 0 ? 0 : weapon.TotalAmmo;

                ref var entity = ref _reloadFinishedFilter.GetEntity(i);
                weapon.Owner.Del<ReloadingComponent>();
                entity.Del<ReloadingFinishedComponent>();
            }
        }
    }
}