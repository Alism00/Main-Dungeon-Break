using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    public int DiamondValue = 1;
    private Player _player;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag==("Player"))
        {
            _player.CollctedDiamond += DiamondValue;
            Destroy(gameObject);
        }
    }
}
