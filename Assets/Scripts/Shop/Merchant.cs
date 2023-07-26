using Game.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    Button SelectedButton;
    private Player player;
    [SerializeField]
    private GameObject _ShopPanel;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        _ShopPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (player != null)
            {
                _ShopPanel.SetActive(true);
            }
            UIManager.Instance.UpdateShop(player.CollctedDiamond);
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
        SelectedButton = button;
        UIManager.Instance.UpdateShopSelection(button);
    }
    public void CloseShop()
    {
        _ShopPanel.SetActive(false);
    }
    public void BuyItem()
    {
        if (SelectedButton != null)
        {
            Items items = SelectedButton.GetComponent<Items>();
            if (player.CollctedDiamond >= items.Price)
            {
                player.CollctedDiamond -= items.Price;
                Debug.Log($"{items.Name} has bought.");
                DisableButton();
                UIManager.Instance.UpdateShop(player.CollctedDiamond);
            }
            else
            {
                Debug.Log("Not enough gem");
            }
        }


    }
    private void DisableButton()
    {
        SelectedButton.interactable = false;
        Text textname = SelectedButton.transform.GetChild(0).GetComponentInChildren<Text>();
        Text textprice = SelectedButton.transform.GetChild(1).GetComponentInChildren<Text>();
        textprice.color = Color.gray;
        textname.color = Color.gray;
        SelectedButton = null;
        UIManager.Instance.SelectionImage.gameObject.SetActive(false);
    }
}
