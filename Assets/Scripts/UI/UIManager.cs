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

    public void OpenShop(int gemcount)
    {
        PlayerGemCountText.text = gemcount.ToString()+"G";
    }
    private void Awake()
    {
        _instance = this;
    }
}
