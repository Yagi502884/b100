using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryChange : MonoBehaviour
{

    public int kind;
    public GameObject[] inventory;
    float startPosX = 0;
    float startPosY = 0;

    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    void Update()
    {
        
    }

    void OnMouseDown(){
        transform.position = new Vector3(startPosX,startPosY,0);
        for(int x=0;x<4;x++){
            if(x!=kind){
                inventory[x].SetActive(false);
            }
            else if(x==kind){
                inventory[x].SetActive(true);
            }
        }
    }

    void OnMouseEnter(){
        transform.position = new Vector3(startPosX,startPosY - 5,0);
    }

    void OnMouseExit(){
        transform.position = new Vector3(startPosX,startPosY,0);
    }
}
