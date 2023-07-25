using Game.Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        UIManager.Instance.UpdateShopSelection(button);
        BuyItem(button);
    }
    public void CloseShop() {
        _ShopPanel.SetActive(false);  
    }
    public void BuyItem(Button button)
    {
       Player player = GameObject.Find("Player").GetComponent<Player>();
      Items items = button.GetComponent<Items>();
         if (player.CollctedDiamond>= items.Price)
        {
           player.CollctedDiamond -=  items.Price;
            Debug.Log($"{items.Name} has bought.");
            button.interactable = false;                      
           Text textname = button.transform.GetChild(0).GetComponentInChildren<Text>() ;
            Text textprice = button.transform.GetChild(1).GetComponentInChildren<Text>();
            textprice.color = Color.gray;
            textname.color = Color.gray;
        }
         else
        {
            Debug.Log("Not enough gem");
        }
    }
}
