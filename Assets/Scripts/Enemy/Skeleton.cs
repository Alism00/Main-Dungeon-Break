using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy,IDamageable
{
    public int Health { get ; set ; }

   

    //start method or initilzation
    public override void Init()
    {
        base.Init();
        Health = health;
    }
    public void Damage()
    {
        if (isDead) return;
        Health--;
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
        isHit = true;
        if (Health <= 0)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamonds = Instantiate(DiamondPrefab, transform.position, Quaternion.identity);
            diamonds.GetComponent<Diamonds>().DiamondValue = gems;
            Destroy(gameObject,3f);
        }
    }
}
