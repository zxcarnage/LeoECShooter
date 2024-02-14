using UnityEngine;

namespace Client.Components
{
    public struct ProjectileComponent
    {
        public Vector3 Direction;
        public float Speed;
        public float Damage;
        public Vector3 PreviousPosition;
        public GameObject ProjectileInstantiated;
        public float ProjectileRadius;
    }
}