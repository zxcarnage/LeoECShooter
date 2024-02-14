using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class PlayerRotateSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        private EcsFilter<PlayerComponent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var player = _filter.Get1(i);

                Plane plane = new Plane(Vector3.up, player.PlayerTransform.position);
                Ray ray = _sceneData.MainCamera.ScreenPointToRay(Input.mousePosition);
                if (plane.Raycast(ray, out var hitDistance))
                    player.PlayerTransform.forward = ray.GetPoint(hitDistance) - player.PlayerTransform.position;
            }
        }
    }
}