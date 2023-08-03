using Game.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;


public class Merchant : MonoBehaviour
{
    [SerializeField]
    private GameObject _HUD;
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
                _HUD.SetActive(false);
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
        _HUD.SetActive(true) ;
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
                BuyRule(items.Name);
                DisableButton();
                UIManager.Instance.GemCounter.text = player.CollctedDiamond.ToString();
                UIManager.Instance.UpdateShop(player.CollctedDiamond);
            }
            else
            {
                Debug.Log("Not enough gem");
            }
        }


    }

    private void BuyRule(string name)
    {
        switch (name)
        {
            case "Key":
                GameManager.Instance.KeyCount++;
                break;
            default:
                break;
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
