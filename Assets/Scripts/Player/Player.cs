using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Game.Player
{
    public class Player : MonoBehaviour,IDamageable
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
        private int _maxLives;
        [SerializeField]
        private bool _resetJumpNeeded = false;
        private PlayerAnimation _playerAnimation;
        public int CollctedDiamond;
        public int Health { get ; set ; }

        // Start is called before the first frame update
        void Start()
        {
            Health = 5;
            _rigidbody = GetComponent<Rigidbody2D>();
            _playerAnimation = GetComponent<PlayerAnimation>();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            NormalAttack();
        }
        void Movement()
        {
            move = Input.GetAxisRaw("Horizontal");
            IsGrounded();
            //jump
            if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
            {
                //_rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _firstJumpForce);
                _playerAnimation.Jump(true);
                StartCoroutine(ResetJumpNeededRoutine());
                
            }
            // Movmen
            _rigidbody.velocity = new Vector2(move * _speed, _rigidbody.velocity.y);
            _playerAnimation.Move(move);
        }

        // check if the player is on ground or in mid air
        bool IsGrounded()
        {
            
            // 1 << 3 means give 1 to 3 place of a binary (layers)
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.65f, 1 << 3);
            Debug.DrawRay(transform.position, Vector2.down * 0.62f, Color.yellow);
            if (hitInfo.collider != null && _resetJumpNeeded == false)
            {
                _playerAnimation.Jump(false);
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
        void NormalAttack()
        {
            if (Input.GetMouseButtonDown(0) && IsGrounded())
            {
                _playerAnimation.NormalAttack();
                StartCoroutine(AttackResetRoutine());
            }
        }

        public void Damage()
        {
            Debug.Log("playhit");
            Health--;
            _playerAnimation.GetHit();
            UIManager.Instance.HealthBarUpdate(Health,_maxLives);
            if (Health <= 0)
            {
                _playerAnimation.Death();
                Destroy(gameObject,1f);
            }
        }
        IEnumerator AttackResetRoutine()
        {
            yield return new WaitForSeconds(0.5f);
        }
    }
}
