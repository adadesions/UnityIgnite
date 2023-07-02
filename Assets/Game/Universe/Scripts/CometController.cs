using UnityEngine;

namespace Game.Universe.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class CometController : MonoBehaviour
    {
        private Rigidbody _rb;

        [SerializeField]
        private float _spinForce = 1.0f;

        [SerializeField]
        private float _directionForce = 1.0f;

        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.AddTorque(_spinForce * Vector3.up, ForceMode.Impulse);
            _rb.AddForce(_directionForce * Vector3.forward, ForceMode.Impulse);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
