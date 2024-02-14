using Client.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        private EcsWorld _ecsWorld;

        private EcsEntity _playerEntity;
        private GameObject _playerInstantiated;
        public void Init()
        {
            _playerEntity = _ecsWorld.NewEntity();
            InitPlayer();
            InitWeapon();
            
        }

        private void InitWeapon()
        {
            ref var hasWeapon = ref _playerEntity.Get<HasWeaponComponent>();
            var weaponEntity = _ecsWorld.NewEntity();
            hasWeapon.Weapon = weaponEntity;
            var weaponView = _playerInstantiated.GetComponentInChildren<WeaponSettings>();
            ref var weapon = ref weaponEntity.Get<WeaponComponent>();
            weapon.Owner = _playerEntity;
            weapon.WeaponDamage = weaponView.WeaponDamage;
            weapon.ProjectileRadius = weaponView.ProjectileRadius;
            weapon.TotalAmmo = weaponView.TotalAmmo;
            weapon.ProjectileSpeed = weaponView.ProjectileSpeed;
            weapon.ProjectileSocket = weaponView.ProjectileSocket;
            weapon.ProjectilePrefab = weaponView.BulletPrefab;
            weapon.MaxAmmo = weaponView.MaxInMagazine;
            weapon.CurrentAmmo = weaponView.CurrentInMagazine;
        }

        private void InitPlayer()
        {
            ref var player = ref _playerEntity.Get<PlayerComponent>();
            ref var inputData = ref _playerEntity.Get<PlayerInputData>();
            ref var animatorRef = ref _playerEntity.Get<AnimatorRef>();
            
            _playerInstantiated = Object.Instantiate(_staticData.PlayerPrefab, _sceneData.SpawnPoint);
            _playerInstantiated.GetComponentInChildren<PlayerView>().SetPlayerEntity(_playerEntity);
            player.Rigidbody = _playerInstantiated.GetComponent<Rigidbody>();
            player.PlayerAnimator = _playerInstantiated.GetComponentInChildren<Animator>();
            player.PlayerSpeed = _staticData.PlayerSpeed;
            player.PlayerTransform = _playerInstantiated.transform;
            animatorRef.Animator = player.PlayerAnimator;
        }
    }
}