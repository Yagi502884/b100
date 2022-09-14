using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public GameObject inventory;
    public GameObject buttons;

    float startPosY = 0;

    void Start()
    {
        startPosY = transform.position.y;
    }

    void Update()
    {
        
    }

    void OnMouseDown(){
        transform.position = new Vector3(-200,startPosY,0);
        inventory.SetActive(true);
        buttons.SetActive(false);
    }

    void OnMouseEnter(){
        transform.position = new Vector3(-180,startPosY,0);
    }

    void OnMouseExit(){
        transform.position = new Vector3(-200,startPosY,0);
    }
}
