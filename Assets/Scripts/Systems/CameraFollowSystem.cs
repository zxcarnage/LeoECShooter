using Client;
using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        
        private EcsFilter<PlayerComponent> _filter;
        private Vector3 _currentVelocity;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var player = ref _filter.Get1(i);
                var camera = _sceneData.MainCamera;

                var currentPos = camera.transform.position;
                currentPos = Vector3.SmoothDamp(currentPos, 
                    player.PlayerTransform.position + _staticData.CameraOffset,
                    ref _currentVelocity, _staticData.SmoothTime);
                camera.transform.position = currentPos;
            }
        }
    }
}