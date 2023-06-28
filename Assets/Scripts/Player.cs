using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _speed = 5;
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
        float HorizontalInput = Input.GetAxisRaw("Horizontal");

        _rigidbody.velocity = (new Vector2(HorizontalInput, _rigidbody.velocity.y)) * _speed * Time.fixedDeltaTime;
    }
}
