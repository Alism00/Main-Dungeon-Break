using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int Power;
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
    protected bool isHit = false;
    public GameObject DiamondPrefab;
    protected bool isDead= false;

    protected Player player;

   

    public virtual void Init()
    {
        
        targetPosition = PointB.position;
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        Init();
    }
    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            return;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            return;
        }
        Movement();
    }
    public virtual void Movement()
    {
        if (targetPosition == PointA.position)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
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
        if (!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        float distance = Vector3.Distance(player.transform.localPosition,transform.localPosition);
        if (distance >= 2f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        Vector3 direction = player.transform.localPosition - transform.localPosition;
        if(direction.x >= 0 && anim.GetBool("InCombat"))
        {
            transform.localScale = new Vector3 (1,1,1);
        }
        if(direction.x <0&& anim.GetBool("InCombat"))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

   
}
