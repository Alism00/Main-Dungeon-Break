using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new UnityException();
            }
            return _instance;
        }
    }
    public int KeyCount { get; set; }
    public void FireSword()
    {
        player.FireSword();
    }
    public bool FlightBoots { get; set; } = false;
    private void Awake()
    {
        _instance = this;
        player = GameObject.Find("Player").GetComponent<Player>();
    }

}
