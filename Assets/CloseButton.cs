using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public ItemManager im;
    public GameObject off;
    public GameObject on;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown(){
        im.Rewrite();
        im.Transition();
        off.SetActive(false);
        on.SetActive(true);
        transform.localScale = new Vector3(1f,1f,1f);
    }

    void OnMouseEnter(){
        transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }

    void OnMouseExit(){
        transform.localScale = new Vector3(1f,1f,1f);
    }
}
