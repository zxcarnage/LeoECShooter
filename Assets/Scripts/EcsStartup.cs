using System;
using Client.Components;
using Client.Systems;
using Leopotam.Ecs;
using Systems;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour
    {

        [SerializeField] private StaticData _configuration;
        [SerializeField] private SceneData _sceneData;
        private RuntimeData _runtimeData;
        
        private EcsWorld _world;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;
        private EcsSystems _lateUpdateSystem;

        private void Start () {
            
            _world = new EcsWorld ();
            CreateSystems();
            _runtimeData = new RuntimeData();
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_updateSystems);
#endif
            AddUpdateSystems();

            AddFixedUpdateSystems();

            AddLateUpdateSystems();

            InitSystems();
        }

        private void AddUpdateSystems()
        {
            _updateSystems
                .Add(new PlayerInitSystem())
                .OneFrame<TryReloadComponent>()
                .Add(new PlayerInputSystem())
                .Add(new PlayerRotateSystem())
                .Add(new PlayerAnimationSystem())
                .Add(new ProjectileHitSystem())
                .Add(new ProjectileMoveSystem())
                .Add(new ReloadingSystem())
                .Add(new SpawnProjectileSystem())
                .Add(new WeaponShootSystem())
                .Inject(_configuration)
                .Inject(_sceneData)
                .Inject(_runtimeData);
        }

        private void AddFixedUpdateSystems()
        {
            _fixedUpdateSystems
                .Add(new PlayerMoveSystem());
        }

        private void AddLateUpdateSystems()
        {
            _lateUpdateSystem
                .Add(new CameraFollowSystem())
                .Inject(_configuration)
                .Inject(_sceneData);
        }

        private void InitSystems()
        {
            _lateUpdateSystem.Init();
            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        private void Update () {
            _updateSystems?.Run ();
        }

        private void FixedUpdate()
        {
            _fixedUpdateSystems?.Run();
        }

        private void LateUpdate()
        {
            _lateUpdateSystem?.Run();
        }

        private void OnDestroy ()
        {
            TryDestroy(_lateUpdateSystem);
            TryDestroy(_fixedUpdateSystems);
            if (TryDestroy(_updateSystems)) {
                _world.Destroy ();
                _world = null;
            }
        }

        private void CreateSystems()
        {
            _updateSystems = new EcsSystems (_world);
            _fixedUpdateSystems = new EcsSystems (_world);
            _lateUpdateSystem = new EcsSystems(_world);
        }

        private bool TryDestroy(EcsSystems systems)
        {
            if (systems != null)
            {
                systems.Destroy();
                systems = null;
                return true;
            }

            return false;
        }
    }
}