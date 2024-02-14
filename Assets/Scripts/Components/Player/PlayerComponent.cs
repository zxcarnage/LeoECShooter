using UnityEngine;

namespace Client.Components
{
    public struct PlayerComponent
    {
        public Animator PlayerAnimator;
        public Rigidbody Rigidbody;
        public Transform PlayerTransform;
        public float PlayerSpeed;
    }
}