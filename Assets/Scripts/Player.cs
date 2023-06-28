using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _speed = 5;
    [SerializeField]
    private float _firstJumpForce = 10f;
    //[SerializeField]
    //private float _secondJumpForce = 2f;
    private float move;
    //[SerializeField]
    //private int _jumplevel = 0;
    [SerializeField]
    private bool _resetJumpNeeded = false;
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
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            //_rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _firstJumpForce);
            StartCoroutine(ResetJumpNeededRoutine());
        }
        // Movment   
        _rigidbody.velocity = new Vector2(move, _rigidbody.velocity.y) * _speed;
    }

    // check if the player is on ground or in mid air
    bool IsGrounded()
    {
        // 1 << 3 means give 1 to 3 place of a binary (layers)
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.62f, 1 << 3);
        Debug.DrawRay(transform.position, Vector2.down * 0.62f, Color.yellow);
        if (hitInfo.collider != null && _resetJumpNeeded == false)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    IEnumerator ResetJumpNeededRoutine()
    {
        _resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
    }
}
