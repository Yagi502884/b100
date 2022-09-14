using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynthesisButton : MonoBehaviour
{
    public MoneyManager mm;
    public ItemList itemList;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown(){
        itemList.Synthesis();
    }

    void OnMouseEnter(){
        GetComponent<Image>().color = new Color32 (128, 128, 128, 255);
    }

    void OnMouseExit(){
        GetComponent<Image>().color = new Color32 (255, 255, 255, 255);
    }
}
