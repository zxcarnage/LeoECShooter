using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private Vector3 _cameraOffset;
        [SerializeField] private float _smoothTime;
        
        public GameObject PlayerPrefab => _playerPrefab;
        public float PlayerSpeed => _playerSpeed;
        public float SmoothTime => _smoothTime;
        public Vector3 CameraOffset => _cameraOffset;
    }
}