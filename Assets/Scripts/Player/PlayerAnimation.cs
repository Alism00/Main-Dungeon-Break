using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
namespace Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator _playerAnim;
        private SpriteRenderer _playerRenderer;
        private Animator _swordArc;
        private SpriteRenderer _swrodArcRenderer;
        // Start is called before the first frame update
        void Start()
        {
            _playerAnim = GetComponentInChildren<Animator>();
            _swordArc = transform.GetChild(1).GetComponent<Animator>();
            _playerRenderer = GetComponentInChildren<SpriteRenderer>();
            _swrodArcRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        public void Move(float move)
        {
            _playerAnim.SetFloat("Move", math.abs(move));
            FlipInAnimation(move);
            
        }
        public void Jump(bool jumped)
        {
            _playerAnim.SetBool("Jump", jumped);
        }
        public void NormalAttack()
        {
            _playerAnim.SetTrigger("NormalAttack");
            _swordArc.SetTrigger("SwordArc");
        }
        private void FlipInAnimation(float num)
        {
            if (num > 0)
            {
                _playerRenderer.flipX = false;
                _swrodArcRenderer.flipX=false;
                
            }
            else if (num < 0)
            {
                _playerRenderer.flipX = true;
                _swrodArcRenderer.flipX = true;
                
            }
        }
    }
}
