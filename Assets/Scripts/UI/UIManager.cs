using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
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
    public Text PlayerGemCountText;
    public Image SelectionImage;

    public void OpenShop(int gemcount)
    {
        PlayerGemCountText.text = gemcount.ToString()+"G";
    }
    public void CloseShop() { }
    public void UpdateShopSelection(Button button)
    {

        if (button.tag == "Item")
        {
            SelectionImage.gameObject.SetActive(true);
            SelectionImage.rectTransform.anchoredPosition = new Vector2(button.transform.localPosition.x + 40 , button.transform.localPosition.y-40);
        }
    }
    private void Awake()
    {
        _instance = this;
    }
}
