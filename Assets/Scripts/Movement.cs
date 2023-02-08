using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Death))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _thrust = 5f;
    [SerializeField] private float _break = 5f;
    [SerializeField] private bool _isMoving;
    [SerializeField] private bool _isStoping;

    [Header("GroundCheck")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float circleRadius;
    [SerializeField] private Transform circleCenter;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(circleCenter.position, circleRadius, groundMask);
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.D))
            {
                _isMoving = true;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                _isMoving = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                _isStoping = true;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                _isStoping = false;
            }
        }
        else
        {
            _isMoving = false;
            _isStoping = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        {

            Vector2 MoveDirection = transform.right * _thrust * Time.deltaTime;
            rb.AddForce(MoveDirection, ForceMode2D.Force);
        }

        if (_isStoping && rb.velocity.magnitude > 1)
        {

            Vector2 MoveDirection = -transform.right * _break * Time.deltaTime;
            rb.AddForce(MoveDirection, ForceMode2D.Force);
        }
    }



}
