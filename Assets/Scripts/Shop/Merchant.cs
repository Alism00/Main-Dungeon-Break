using Game.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                _ShopPanel.SetActive(true);
            }
            UIManager.Instance.OpenShop(player.CollctedDiamond);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _ShopPanel.SetActive(false);
        }
    }
    public void SelectItem(Button button)
    {

        Debug.Log(button.ToString());
    }
}
