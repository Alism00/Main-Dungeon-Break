using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    [SerializeField]
    private Animator _anim;
    private bool _switch = false;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _anim =transform.GetChild(0).GetComponent<Animator>();
    }
    public override void Update()
    {

        if (transform.position == PointA.position)
        {
            
            StartCoroutine(IdelAnimationRoutine());
            _switch = false;
            
            transform.position = Vector3.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);

        }
        else if (transform.position == PointB.position)
        {
           
            StartCoroutine(IdelAnimationRoutine());
            _switch = true;
           
            transform.position = Vector3.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);

        }
        if (_switch)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointA.position, speed * Time.deltaTime);
        }
        else if (!_switch)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointB.position, speed * Time.deltaTime);
        }
    }
    IEnumerator IdelAnimationRoutine()
    {
        _anim.SetTrigger("Idle");
        yield return new WaitForSeconds(1.45f);
         
        _renderer.flipX = !_renderer.flipX;
    }
}

