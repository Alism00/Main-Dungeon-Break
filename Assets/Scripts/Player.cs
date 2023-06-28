using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _speed = 100;
    private bool _isGrounded = true;
    [SerializeField]
    private float _jumpForce = 100;
    private float move;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        move = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rigidbody.AddForce(transform.up * -_jumpForce);
            }
        }
        _rigidbody.velocity = new Vector2 (move,_rigidbody.velocity.y);
    }
}
