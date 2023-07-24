using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField]
    private GameObject _ShopPanel;
    private void Start()
    {
        _ShopPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _ShopPanel.SetActive(true);
        }
    }
}
