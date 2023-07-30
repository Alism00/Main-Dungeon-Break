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
    public Text GemCounter;
    public Image[] images;
    public void UpdateShop(int gemcount)
    {

        PlayerGemCountText.text = gemcount.ToString()+"G";
    }
    
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
    public void HealthBarUpdate(int lives,int maxlives)
    {

       
        for (int i = 0; i < images.Length; i++)
        {

            if (i < lives)
            {
                images[i].enabled = true;
            }
            else
            {
                images[i].enabled = false;
            }
        }
    }
}
