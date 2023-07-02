using System.Collections.Generic;
using UnityEngine;

namespace Game.FirstGame.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        // Singleton Pattern Design
        private PlayerManager _instance;
        [SerializeField] private List<Transform> _spawnerLocation;
        [SerializeField] private GameObject _playerPrefab;
        private GameObject _player;

        public PlayerManager Instance
        {
            get => _instance;
            set => _instance = value;
        }
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
                return;
            }

            _instance = this;
        }

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            if (_player) return;
            
            int randIdx = Random.Range(0, _spawnerLocation.Count);
            Vector3 randLocation = _spawnerLocation[randIdx].position;
            _player = Instantiate(_playerPrefab, randLocation, Quaternion.identity);
            CameraManager.Instance.SetVirtualCamera(_player.transform);
        }
    }
}
