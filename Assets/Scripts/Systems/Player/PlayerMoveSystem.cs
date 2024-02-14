using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, PlayerInputData> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var player = _filter.Get1(i);
                var playerInput = _filter.Get2(i);
                var playerTransform = player.PlayerTransform;
                /*Debug.Log(playerInput.MoveInput.z);*/
                var direction = (Vector3.forward * playerInput.MoveInput.z +
                                 Vector3.right * playerInput.MoveInput.x);
                player.Rigidbody.velocity = new Vector3(direction.x * player.PlayerSpeed
                    , player.Rigidbody.velocity.y
                    , direction.z * player.PlayerSpeed);
            }
        }
    }
}