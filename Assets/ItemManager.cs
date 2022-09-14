using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public ItemList[] il;
    public TextMeshProUGUI[] playerInfo;
    public TextMeshProUGUI[] equipInfo;
    int[] textNum = {0,0,0,0};

    public ItemList[] allIL;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        
    }

    public void Save(){
        for(int x=0;x<20;x++){
            PlayerPrefs.SetInt("Weapon" + x,il[0].baseItemState[x]);
            PlayerPrefs.SetInt("WeaponLevel" + x,il[0].itemLevel[x]);
            PlayerPrefs.SetInt("aWeapon" + x,il[0].aWeapon[x]);
            PlayerPrefs.SetInt("sWeapon" + x,il[0].sWeapon[x]);
        }
        for(int x=0;x<20;x++){
            PlayerPrefs.SetInt("Helmet" + x,il[1].baseItemState[x]);
            PlayerPrefs.SetInt("HelmetLevel" + x,il[1].itemLevel[x]);
            PlayerPrefs.SetInt("dHelmet" + x,il[0].dHelmet[x]);
            PlayerPrefs.SetInt("hHelmet" + x,il[0].hHelmet[x]);
            PlayerPrefs.SetInt("sHelmet" + x,il[0].sHelmet[x]);
        }
        for(int x=0;x<20;x++){
            PlayerPrefs.SetInt("Chest" + x,il[2].baseItemState[x]);
            PlayerPrefs.SetInt("ChestLevel" + x,il[2].itemLevel[x]);
            PlayerPrefs.SetInt("dChest" + x,il[0].dChest[x]);
            PlayerPrefs.SetInt("hChest" + x,il[0].hChest[x]);
            PlayerPrefs.SetInt("sChest" + x,il[0].sChest[x]);
        }
        for(int x=0;x<20;x++){
            PlayerPrefs.SetInt("Boots" + x,il[3].baseItemState[x]);
            PlayerPrefs.SetInt("BootsLevel" + x,il[3].itemLevel[x]);
            PlayerPrefs.SetInt("dBoots" + x,il[0].dBoots[x]);
            PlayerPrefs.SetInt("hBoots" + x,il[0].hBoots[x]);
            PlayerPrefs.SetInt("sBoots" + x,il[0].sBoots[x]);
        }
    }

    //hp0 attack1 defense2 speed3
    public void Rewrite(){

        if(il[0].equipOrder>=0){
            Debug.Log("weapon");
            textNum[1] += il[0].aWeapon[il[0].equipOrder];
            textNum[3] += il[0].sWeapon[il[0].equipOrder];
        }
        if(il[1].equipOrder>=0){
            Debug.Log("helmet");
            textNum[0] += il[1].hHelmet[il[1].equipOrder];
            textNum[2] += il[1].dHelmet[il[1].equipOrder];
            textNum[3] += il[1].sHelmet[il[1].equipOrder];
        }
        if(il[2].equipOrder>=0){
            Debug.Log("chest");
            textNum[0] += il[2].hChest[il[2].equipOrder];
            textNum[2] += il[2].dChest[il[2].equipOrder];
            textNum[3] += il[2].sChest[il[2].equipOrder];
        }
        if(il[3].equipOrder>=0){
            Debug.Log("boots");
            textNum[0] += il[3].hBoots[il[3].equipOrder];
            textNum[2] += il[3].dBoots[il[3].equipOrder];
            textNum[3] += il[3].sBoots[il[3].equipOrder];
        }
        for(int x=0;x<4;x++){
            equipInfo[x].text = textNum[x].ToString("");
            textNum[x] = 0;
        }
    }

    public void Transition(){
        Debug.Log("transition");
        for(int x=0;x<allIL.Length;x++){
            allIL[x].Load();
        }
    }
}
