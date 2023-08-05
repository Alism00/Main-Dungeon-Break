using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    public int Power;
    private bool _canAttack = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        IDamageable hit = other.GetComponent<IDamageable>();
        if (this.gameObject.transform.root.tag == "Enemy")
        {
            Enemy enemy = gameObject.transform.root.GetComponent<Enemy>();
            Power = enemy.Power;
        }
        else if (this.gameObject.transform.root.tag == "Player")
        {
            Player player = gameObject.transform.root.GetComponent<Player>();
            Power = player.Power;
        }

        if(hit != null)
        {
            if (_canAttack)
            {

                hit.Damage(Power);
                
            }
            _canAttack = false;
           StartCoroutine(ResetAttack());
        }

    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.3f);
        _canAttack = true;
    }
    
    
}
