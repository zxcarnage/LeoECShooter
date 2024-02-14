using Client.Components;
using Leopotam.Ecs;

namespace Systems
{
    public class ProjectileHitSystem : IEcsRunSystem
    {
        private EcsFilter<ProjectileComponent, ProjectileHitComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var projectile = ref _filter.Get1(i);
                
                projectile.ProjectileInstantiated.gameObject.SetActive(false);
            }    
        }
    }
}