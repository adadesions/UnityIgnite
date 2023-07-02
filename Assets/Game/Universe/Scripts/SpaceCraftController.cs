using UnityEngine;

namespace Game.Universe.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class SpaceCraftController : MonoBehaviour
    {
        private Rigidbody _rb;

        private Vector2 _input;
        private float _height;
        private Vector3 _nextPos;
        
        [SerializeField]
        private float _deltaHeight = 0.001f;
        [SerializeField]
        private float _speed = 1.0f;

        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _height = _rb.position.y;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Movements();
        }

        private void Movements()
        {
            _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            _height = 0;
            if (Input.GetKey(KeyCode.Q))
                _height = _deltaHeight;
            
            if (Input.GetKey(KeyCode.E))
                _height = -_deltaHeight;
            
            if (_input.magnitude == 0) return;

            _nextPos = _rb.position + _speed * Time.fixedDeltaTime * new Vector3(_input.x, _height, _input.y);
            _rb.position = _nextPos;
        }
    }
}
