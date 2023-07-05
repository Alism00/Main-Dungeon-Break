using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform PointA, PointB;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Vector3 targetPosition;
    public virtual void Init()
    {
        targetPosition= PointB.position;
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        Movement();
    }
    public virtual void Movement()
    {
        if (targetPosition == PointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        if (transform.position == PointA.position)
        {
            targetPosition = PointB.position;
            anim.SetTrigger("Idle");

        }
        else if (transform.position == PointB.position)
        {
            targetPosition = PointA.position;
            anim.SetTrigger("Idle");

        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
