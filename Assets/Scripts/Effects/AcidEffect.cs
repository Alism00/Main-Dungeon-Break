using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
   
    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.Translate(Vector2.right * 3 * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other)
        
    {
        if (other.tag == "Player")
        {
         IDamageable Hit = other.GetComponent<IDamageable>();
            if (Hit != null)
            {
                
                Hit.Damage();
                Destroy(gameObject);

            }
        }
       
    }
}
