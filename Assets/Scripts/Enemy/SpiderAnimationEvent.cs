using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    
    private Spider _Spider;
    private void Start()
    {
        _Spider =transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        _Spider.Attack();
    }
}
