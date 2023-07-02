using Cinemachine;
using UnityEngine;

namespace Game.FirstGame.Scripts
{
    public class CameraManager : MonoBehaviour
    {
        private static CameraManager _instance;
        [SerializeField] private CinemachineFreeLook _vCinemachineFreeLook;

        public static CameraManager Instance
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

        public void SetVirtualCamera(Transform target)
        {
            _vCinemachineFreeLook.Follow = target;
            _vCinemachineFreeLook.LookAt = target;
        }
    }
}
