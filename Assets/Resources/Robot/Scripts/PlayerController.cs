using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class = Blueprint
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;

    private Rigidbody _rb;
    private Animator m_anim;
    private Vector3 _moveInput;
    private float m_lastTimeSit;
    private bool m_isSitting = false;

    [SerializeField] private float test = 1.0f;
    private static readonly int IsSitting = Animator.StringToHash("IsSitting");
    private Camera _camera;
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
        m_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movements();
        ListeningSittingEvent();
    }

    private void ListeningSittingEvent()
    {
        if (!Input.GetKey(KeyCode.RightCommand) || !(Time.time > m_lastTimeSit + 0.7)) return;
        m_lastTimeSit = Time.time;
        m_isSitting = !m_isSitting;
        m_anim.SetBool(IsSitting, m_isSitting);
    }

    private void Movements()
    {
        _moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        var moveDirection = _moveInput.normalized;

        if (_camera)
        {
            var targetAngel =
                Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg
                + _camera.transform.eulerAngles.y;
            var rotateTo = Quaternion.Euler(0, targetAngel, 0);

            if (_moveInput.magnitude > 0) {
                var headingDirection = rotateTo * Vector3.forward;
                var newPos = _rb.position + speed * Time.fixedDeltaTime * headingDirection;
                _rb.MovePosition(newPos);
                _rb.MoveRotation(rotateTo);
            }
        }

        PlayRunAnimation();
    }

    private void PlayRunAnimation()
    {
        m_anim.SetBool(IsRunning, _moveInput.magnitude > 0);
    }
}
