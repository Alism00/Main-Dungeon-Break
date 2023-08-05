using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField]
    private GameObject _acid;
    
    float distance;
    public int Health { get; set; }

    //start method or initilzation
    public override void Init()
    {

        base.Init();
        Power = 1;
        Health = health;
    }
    public void Damage(int power)
    {
        if (isDead) return;
        Health -= power;
        anim.SetBool("InCombat", true);
        isHit = true;
        if (Health <= 0)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamonds = Instantiate(DiamondPrefab,transform.position,Quaternion.identity);
            diamonds.GetComponent<Diamonds>().DiamondValue = gems;
            Destroy(gameObject, 1.1f);
        }
    }

    public override void Update()
    {
        AttackTime();
    }
    public override void Movement()
    {
        // stay still
    }
    public void Attack()
    {
        Instantiate(_acid, transform.position, Quaternion.identity,transform);
    }

    private void AttackTime()
    {
        distance = Vector3.Distance(player.transform.localPosition, transform.localPosition);
        //Debug.Log(distance);
        if (distance >= 4f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        if (distance <= 4)
        {
            isHit = true;
            anim.SetBool("InCombat", true);
        }
    }
}
