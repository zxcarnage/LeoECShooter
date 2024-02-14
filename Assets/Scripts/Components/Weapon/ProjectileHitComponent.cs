using Leopotam.Ecs;
using UnityEngine;

namespace Client.Components
{
    public struct ProjectileHitComponent : IEcsIgnoreInFilter
    {
        public RaycastHit HitInfo;
    }
}