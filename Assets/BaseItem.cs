using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseItem : MonoBehaviour
{
    public int order;
    public Image itemImage;
    public TextMeshProUGUI levelText;
    public ItemList itemList;
    public Image cover;

    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnMouseDown(){
        bool origin = true;
        if(itemList.baseItemState[order] > 0){
            if(itemList.windowKind != 2){
                itemImage.color = new Color32 (255, 255, 255, 128);
                for(int x = 0;x < itemList.baseItem.Length;x++){
                    if(itemList.baseItemState[x] < 0)origin = false;
                }
                if(origin == true){
                    itemList.originOrder = order;
                    itemImage.color = new Color32 (192, 192, 192, 128);
                }
            }
            if(itemList.windowKind == 2){
                for(int x = 0;x < itemList.baseItem.Length;x++){
                    if(itemList.baseItemState[x] < 0){
                        origin = false;
                    }
                }
                if(origin == true){
                    itemList.originOrder = order;
                    itemImage.color = new Color32 (192, 192, 192, 128);
                }
            }
        }

        if(itemList.baseItemState[order] < 0){
            itemImage.color = new Color32 (255, 255, 255, 255);
            itemList.ItemImageDelete(order);
            if(itemList.originOrder == order)
            {
                itemList.originOrder = -1;
            }

                if(itemList.windowKind == 2){
                    Debug.Log(itemList.kind + "aaaaaa");
                    switch(itemList.kind){
                        case 0:PlayerPrefs.SetInt("EquipWeapon",-1);break;
                        case 1:PlayerPrefs.SetInt("EquipHelmet",-1);break;
                        case 2:PlayerPrefs.SetInt("EquipChest",-1);break;
                        case 3:PlayerPrefs.SetInt("EquipBoots",-1);break;
                    }
                }
        }

        if(order == itemList.equipOrder){
            itemImage.color = new Color32 (255, 255, 255, 255);
            itemList.equipOrder = -1;
            itemList.baseItemState[order] *= -1;
            itemList.im.Rewrite();
        }
        if(!(origin == false && itemList.windowKind == 2) && order != itemList.equipOrder){
            itemList.baseItemState[order] *= -1;
        }
        itemList.BenefitCalculate();
        }

    void OnMouseEnter(){
        if(itemList.baseItemState[order] > 0){
            itemImage.color = new Color32 (128, 128, 128, 255);
            itemList.ItemImageDisplay(order);
        }
    }

    void OnMouseExit(){
        if(itemList.baseItemState[order] > 0 && order != itemList.equipOrder){
            itemImage.color = new Color32 (255, 255, 255, 255);
        }
        if(itemList.baseItemState[order] > 0 && order == itemList.equipOrder){
            itemImage.color = new Color32 (64, 64, 64, 255);
        }
    }
}

