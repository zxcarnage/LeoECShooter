using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, PlayerInputData> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var player = _filter.Get1(i);
                var playerInput = _filter.Get2(i);
                
                float vertical = Vector3.Dot(playerInput.MoveInput.normalized, player.PlayerTransform.forward);
                float horizontal = Vector3.Dot(playerInput.MoveInput.normalized, player.PlayerTransform.right);
                player.PlayerAnimator.SetFloat("Horizontal", horizontal, 0.1f, Time.deltaTime);
                player.PlayerAnimator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
                player.PlayerAnimator.SetBool("Shooting", playerInput.ShootInput);
            }
        }
    }
}