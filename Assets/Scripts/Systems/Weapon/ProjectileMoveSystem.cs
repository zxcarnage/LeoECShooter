using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class ProjectileMoveSystem : IEcsRunSystem
    {
        private EcsFilter<ProjectileComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var projectile = ref _filter.Get1(i);

                var position = projectile.ProjectileInstantiated.transform.position;
                position += projectile.Direction * projectile.Speed * Time.deltaTime;
                projectile.ProjectileInstantiated.transform.position = position;

                var displacementSinceLastFrame = position - projectile.PreviousPosition;

                var hit = Physics.SphereCast(projectile.PreviousPosition,
                    projectile.ProjectileRadius,
                    displacementSinceLastFrame.normalized,
                    out var hitInfo,
                    displacementSinceLastFrame.magnitude);
                
                if (hit)
                {
                    ref var entity = ref _filter.GetEntity(i);
                    ref var projectileHit = ref entity.Get<ProjectileHitComponent>();
                    projectileHit.HitInfo = hitInfo;
                }

                projectile.PreviousPosition = projectile.ProjectileInstantiated.transform.position;
            }    
        }
    }
}