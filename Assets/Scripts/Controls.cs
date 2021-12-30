using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    [Header("Speed values")]
    [Range(0f, 15f)]
    public float MoveSpeed = 5f;
    [Range(5f, 15f)]
    public float MaxSpeed = 15f;

    [Header("Script for snake body mechanics")]
    public BodyMechanics Mechanics;

    private Rigidbody _rigidbody;


    private float _tempSpeed;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartMove();
    }


    void Update()
    {
            Movement();
    }

    void Movement()
    {
        Vector3 playerScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = (playerScreenPos - Input.mousePosition).normalized;

        direction.x = -direction.x;
        direction.y = 0;
        direction.z = 1f;

        _rigidbody.AddForce((MoveSpeed * 100f) * direction * Time.fixedDeltaTime);
        if (_rigidbody.velocity.magnitude > MaxSpeed)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * MaxSpeed;
        }
    }

    public void StopMove()
    {
        _tempSpeed = MoveSpeed;
        MoveSpeed = 0f;
    }

    public void StartMove() // Didn't have time to debug, i'm already behind as-is
    {
        if (MoveSpeed == 0f)
        MoveSpeed = _tempSpeed;
    }
}
