using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemList : MonoBehaviour
{
    public TextMeshProUGUI benefitText;
    int benefit = 0;

    public ItemManager im;
    public MoneyManager mm;
    public Detail[] detail;
    public BaseItem[] baseItem;

    string[] weaponName = {"ロングソード","短剣","アックス","ハンマー"};
    string[] armorName = {"軽装","一般装備","重装"};

    string[] weaponDetail = {"長い剣","短い剣","斧","ハンマー"};
    string[] helmetDetail = {"軽い","普通","重いよ"};
    string[] chestDetail = {"軽い","普通","重いよ"};
    string[] bootsDetail = {"軽い","普通","重いよ"};
            
    public Sprite[] weaponImage;

    public int[] weaponAttackValue = {5,3,7,9};
    public int[] weaponSpeedValue = {5,7,3,1};

    public int[] helmetDefenseValue = {2,3,4};
    public int[] helmetHPValue = {2,3,4};
    public int[] helmetSpeedValue = {7,5,3};

    public int[] chestDefenseValue = {4,5,6};
    public int[] chestHPValue = {4,5,6};
    public int[] chestSpeedValue = {7,5,3};

    public int[] bootsDefenseValue = {2,3,5};
    public int[] bootsHPValue = {2,3,5};
    public int[] bootsSpeedValue = {8,6,2};

    public int[] itemLevel;
    public int[] baseItemState;
    public int[] weaponKind;

    public int[] aWeapon = new int[20];
    public int[] sWeapon = new int[20];
    public int[] dHelmet = new int[20];
    public int[] hHelmet = new int[20];
    public int[] sHelmet = new int[20];
    public int[] dChest = new int[20];
    public int[] hChest = new int[20];
    public int[] sChest = new int[20];
    public int[] dBoots = new int[20];
    public int[] hBoots = new int[20];
    public int[] sBoots = new int[20];

    public int[] holdOrder = new int[2];

    public int originOrder = 0;
    public int kind;

    public int equipOrder = -1;

    public int windowKind;
    public Sort sort;

    void Set(){
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Weapon0",10);PlayerPrefs.SetInt("Weapon1",11);PlayerPrefs.SetInt("Weapon2",12);PlayerPrefs.SetInt("Weapon3",13);
        PlayerPrefs.SetInt("Helmet0",20);PlayerPrefs.SetInt("Helmet1",21);PlayerPrefs.SetInt("Helmet2",22);
        PlayerPrefs.SetInt("Chest0",30);PlayerPrefs.SetInt("Chest1",31);PlayerPrefs.SetInt("Chest2",32);
        PlayerPrefs.SetInt("Boots0",40);PlayerPrefs.SetInt("Boots1",41);PlayerPrefs.SetInt("Boots2",42);
        PlayerPrefs.SetInt("aWeapon0",5);PlayerPrefs.SetInt("aWeapon1",3);PlayerPrefs.SetInt("aWeapon2",7);PlayerPrefs.SetInt("aWeapon3",9);
        PlayerPrefs.SetInt("sWeapon0",5);PlayerPrefs.SetInt("sWeapon1",7);PlayerPrefs.SetInt("sWeapon2",3);PlayerPrefs.SetInt("sWeapon3",1);
        PlayerPrefs.SetInt("dHelmet0",2);PlayerPrefs.SetInt("dHelmet1",3);PlayerPrefs.SetInt("dHelmet2",4);
        PlayerPrefs.SetInt("hHelmet0",2);PlayerPrefs.SetInt("hHelmet1",3);PlayerPrefs.SetInt("hHelmet2",4);
        PlayerPrefs.SetInt("sHelmet0",7);PlayerPrefs.SetInt("sHelmet1",5);PlayerPrefs.SetInt("sHelmet2",3);
        PlayerPrefs.SetInt("dChest0",4);PlayerPrefs.SetInt("dChest1",5);PlayerPrefs.SetInt("dChest2",6);
        PlayerPrefs.SetInt("hChest0",4);PlayerPrefs.SetInt("hChest1",5);PlayerPrefs.SetInt("hChest2",6);
        PlayerPrefs.SetInt("sChest0",7);PlayerPrefs.SetInt("sChest1",5);PlayerPrefs.SetInt("sChest2",3);
        PlayerPrefs.SetInt("dBoots0",2);PlayerPrefs.SetInt("dBoots1",3);PlayerPrefs.SetInt("dBoots2",5);
        PlayerPrefs.SetInt("hBoots0",2);PlayerPrefs.SetInt("hBoots1",3);PlayerPrefs.SetInt("hBoots2",5);
        PlayerPrefs.SetInt("sBoots0",8);PlayerPrefs.SetInt("sBoots1",6);PlayerPrefs.SetInt("sBoots2",2);
        Load();
    }

    void Start()
    {
        Load();
    }

    void ColorSort(int x){
        if(baseItemState[x] != 0){
            int power = 0;
            switch(kind){
                case 0:power = aWeapon[x] + sWeapon[x];break;
                case 1:power = dHelmet[x] + hHelmet[x] + sHelmet[x];break;
                case 2:power = dChest[x] + hChest[x] + sChest[x];break;
                case 3:power = dBoots[x] + hBoots[x] + sBoots[x];break;
            }
            if(power > sort.boundary[0])baseItem[x].cover.color = new Color32(240,128,128,64);
            if(power > sort.boundary[1] && power <= sort.boundary[0])baseItem[x].cover.color = new Color32(240,240,128,64);
            if(power <= sort.boundary[1])baseItem[x].cover.color = new Color32(128,240,128,64);
            Debug.Log(power + "power");
        }
        if(baseItemState[x] == 0){
            baseItem[x].cover.color = new Color32(192,192,192,0);
        }
    }

    public void Save(){
        switch(kind){
            case 0:        for(int x=0;x<20;x++){
            PlayerPrefs.SetInt("Weapon" + x,baseItemState[x]);
            PlayerPrefs.SetInt("WeaponLevel" + x,itemLevel[x]);
            PlayerPrefs.SetInt("aWeapon" + x,aWeapon[x]);
            PlayerPrefs.SetInt("sWeapon" + x,sWeapon[x]);
        }break;
            case 1:        for(int x=0;x<20;x++){
            PlayerPrefs.SetInt("Helmet" + x,baseItemState[x]);
            PlayerPrefs.SetInt("HelmetLevel" + x,itemLevel[x]);
            PlayerPrefs.SetInt("dHelmet" + x,dHelmet[x]);
            PlayerPrefs.SetInt("hHelmet" + x,hHelmet[x]);
            PlayerPrefs.SetInt("sHelmet" + x,sHelmet[x]);
        }break;
            case 2:        for(int x=0;x<20;x++){
            PlayerPrefs.SetInt("Chest" + x,baseItemState[x]);
            PlayerPrefs.SetInt("ChestLevel" + x,itemLevel[x]);
            PlayerPrefs.SetInt("dChest" + x,dChest[x]);
            PlayerPrefs.SetInt("hChest" + x,hChest[x]);
            PlayerPrefs.SetInt("sChest" + x,sChest[x]);
        }break;
            case 3:        for(int x=0;x<20;x++){
            PlayerPrefs.SetInt("Boots" + x,baseItemState[x]);
            PlayerPrefs.SetInt("BootsLevel" + x,itemLevel[x]);
            PlayerPrefs.SetInt("dBoots" + x,dBoots[x]);
            PlayerPrefs.SetInt("hBoots" + x,hBoots[x]);
            PlayerPrefs.SetInt("sBoots" + x,sBoots[x]);
        }break;
        }
    }

    public void Load(){
        string kindName = "";
        if(kind == 0)kindName = "Weapon";
        if(kind == 1)kindName = "Helmet";
        if(kind == 2)kindName = "Chest";
        if(kind == 3)kindName = "Boots";
        for(int x=0;x<20;x++){
            baseItemState[x] = PlayerPrefs.GetInt(kindName + x,0);
            itemLevel[x] = PlayerPrefs.GetInt(kindName + "Level" + x,0);
            if(baseItemState[x] >= 10){
                baseItem[x].levelText.text = itemLevel[x].ToString("");
                baseItem[x].itemImage.sprite = weaponImage[baseItemState[x] % 10];
            }
            else{
                baseItem[x].levelText.text = 0.ToString("");
                baseItem[x].itemImage.sprite = null;
            }

            aWeapon[x] = PlayerPrefs.GetInt("aWeapon" + x,0);
            sWeapon[x] = PlayerPrefs.GetInt("sWeapon" + x,0);
            dHelmet[x] = PlayerPrefs.GetInt("dHelmet" + x,0);
            hHelmet[x] = PlayerPrefs.GetInt("hHelmet" + x,0);
            sHelmet[x] = PlayerPrefs.GetInt("sHelmet" + x,0);
            dChest[x] = PlayerPrefs.GetInt("dChest"+ x,0);
            hChest[x] = PlayerPrefs.GetInt("hChest"+ x,0);
            sChest[x] = PlayerPrefs.GetInt("sChest"+ x,0);   
            dBoots[x] = PlayerPrefs.GetInt("dBoots"+ x,0);       
            hBoots[x] = PlayerPrefs.GetInt("hBoots"+ x,0);  
            sBoots[x] = PlayerPrefs.GetInt("sBoots"+ x,0); 

            ColorSort(x);    
        }

        if(windowKind == 2){
            switch(kind){
            case 0:equipOrder = PlayerPrefs.GetInt("EquipWeapon",equipOrder);break;
            case 1:equipOrder = PlayerPrefs.GetInt("EquipHelmet",equipOrder);break;
            case 2:equipOrder = PlayerPrefs.GetInt("EquipChest",equipOrder);break;
            case 3:equipOrder = PlayerPrefs.GetInt("EquipBoots",equipOrder);break;
            }
            if(equipOrder >= 0)baseItem[equipOrder].itemImage.color = new Color32 (64, 64, 64, 255);

            int ew = PlayerPrefs.GetInt("EquipWeapon",-1);
            int eh = PlayerPrefs.GetInt("EquipHelmet",-1);
            int ec = PlayerPrefs.GetInt("EquipChest",-1);
            int eb = PlayerPrefs.GetInt("EquipBoots",-1);
            int a = 0;int d = 0;int h = 0;int s = 0;
            if(ew >= 0){a+=aWeapon[ew];s+=sWeapon[ew];}
            if(eh >= 0){d+=dHelmet[eh];h+=hHelmet[eh];s+=sHelmet[eh];}
            if(ec >= 0){d+=dChest[ec];h+=hChest[ec];s+=sChest[ec];}
            if(eb >= 0){d+=dBoots[eb];h+=hBoots[eb];s+=sBoots[eb];}

            PlayerPrefs.SetInt("EquipAttack",a);
            PlayerPrefs.SetInt("EquipDefense",d);
            PlayerPrefs.SetInt("EquipHP",h);
            PlayerPrefs.SetInt("EquipSpeed",s);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            Save();
            Debug.Log("Saved");
        }
        if(Input.GetKeyDown(KeyCode.R)){
            im.Rewrite();
            Debug.Log("Rewrited");
        }
        if(Input.GetKeyDown(KeyCode.L)){
            Load();
            Debug.Log("Load");
        }
        if(Input.GetKeyDown(KeyCode.E)){
            Set();
            Debug.Log("Set");
        }
        if(Input.GetKeyDown(KeyCode.D)){
            PlayerPrefs.DeleteAll();
        }
    }

    public void BenefitCalculate(){
        benefit=0;
        for(int x = 0;x < baseItem.Length;x++){
            if(baseItemState[x]<0){
                switch(kind){
                    case 0:benefit += (aWeapon[x] + sWeapon[x]) * 5;break;
                    case 1:benefit += (dHelmet[x] + hHelmet[x] + sHelmet[x]) * 5;break;
                    case 2:benefit += (dChest[x] + hChest[x] + sChest[x]) * 5;break;
                    case 3:benefit += (dBoots[x] + hBoots[x] + sBoots[x]) * 5;break;
                }
            }
        }
        benefitText.text = benefit.ToString("");
    }

    public void Synthesis(){
        int preparedBaseItemNum = 0;
        for(int x = 0;x < baseItem.Length;x++){
            if(baseItemState[x]<0){
                preparedBaseItemNum += 1;
            }
        }

        //合成
        if(preparedBaseItemNum == 2 && originOrder >= 0 && mm.cost[kind] <= mm.money){
            mm.Buy(kind);
            int backNum = 0;
            int nextNum = 0;
            int[] ingredientLevelNum = {0,0};
            int[] status = new int[3];
            int synthesisResultNum = Mathf.Abs(baseItemState[originOrder]);
            for(int x = 0;x < baseItem.Length;x++){
                if(baseItemState[x] == 0){
                    baseItem[x].itemImage.sprite = null;
                    itemLevel[x] = 0;
                    baseItem[x].levelText.text = itemLevel[x].ToString("");
                    nextNum = x - 2;

                    switch(kind){
                        case 0:aWeapon[x] = 0;sWeapon[x] = 0;break;
                        case 1:dHelmet[x] = 0;hHelmet[x] = 0;sHelmet[x] = 0; break;
                        case 2:dChest[x] = 0;hChest[x] = 0;sChest[x] = 0;break;
                        case 3:dBoots[x] = 0;hBoots[x] = 0;sBoots[x] = 0;break;
                    }

                    break;
                }
                if(baseItemState[x] < 0){
                    ingredientLevelNum[backNum] = itemLevel[x];
                    switch(kind){
                        case 0:status[0] += aWeapon[x];status[1] += sWeapon[x];break;
                        case 1:status[0] += dHelmet[x];status[1] += hHelmet[x];status[2] += sHelmet[x]; break;
                        case 2:status[0] += dChest[x];status[1] += hChest[x];status[2] += sChest[x];break;
                        case 3:status[0] += dBoots[x];status[1] += hBoots[x];status[2] += sBoots[x];break;
                    }

                    itemLevel[x] = 0;
                    baseItem[x].itemImage.sprite = null;
                    backNum += 1;
                    baseItemState[x] = 0;
                }
                if(baseItemState[x] > 0 && backNum != 0){
                    switch(kind){
                        case 0:aWeapon[x - backNum] = aWeapon[x];sWeapon[x - backNum] = sWeapon[x];break;
                        case 1:dHelmet[x - backNum] = dHelmet[x];hHelmet[x - backNum] = hHelmet[x];sHelmet[x - backNum] = sHelmet[x]; break;
                        case 2:dChest[x - backNum] = dChest[x];hChest[x - backNum] = hChest[x];sChest[x - backNum] = sChest[x]; break;                       
                        case 3:dBoots[x - backNum] = dBoots[x];hBoots[x - backNum] = hBoots[x];sBoots[x - backNum] = sBoots[x]; break;
                    }
                    itemLevel[x - backNum] = itemLevel[x];
                    baseItem[x - backNum].levelText.text = itemLevel[x - backNum].ToString("");
                    itemLevel[x] = 0;
                    baseItem[x].levelText.text = itemLevel[x].ToString("");

                    baseItemState[x - backNum] = baseItemState[x];
                    baseItem[x - backNum].itemImage.sprite = weaponImage[baseItemState[x - backNum] % 10];
                    baseItem[x].itemImage.sprite = null;
                    baseItemState[x] = 0;

                    if(equipOrder == x){equipOrder -= backNum;}
                }
            }

            //合成してできたやつ
            baseItemState[nextNum] = synthesisResultNum;
            baseItem[nextNum].itemImage.sprite = weaponImage[baseItemState[nextNum] % 10];
            itemLevel[nextNum] = ingredientLevelNum[0] + ingredientLevelNum[1];
            baseItem[nextNum].levelText.text = itemLevel[nextNum].ToString("");

            switch(kind){
                case 0:aWeapon[nextNum] = status[0];sWeapon[nextNum] = status[1];break;
                case 1:dHelmet[nextNum] = status[0];hHelmet[nextNum] = status[1];sHelmet[nextNum] = status[2]; break;
                case 2:dChest[nextNum] = status[0];hChest[nextNum] = status[1];sChest[nextNum] = status[2];break;
                case 3:dBoots[nextNum] = status[0];hBoots[nextNum] = status[1];sBoots[nextNum] = status[2];break;
            }

            itemLevel[nextNum + 1] = 0;
            baseItem[nextNum + 1].levelText.text = itemLevel[nextNum + 1].ToString("");
            switch(kind){
                case 0:aWeapon[nextNum + 1] = 0;sWeapon[nextNum + 1] = 0;break;
                case 1:dHelmet[nextNum + 1] = 0;hHelmet[nextNum + 1] = 0;sHelmet[nextNum + 1] = 0; break;
                case 2:dChest[nextNum + 1] = 0;hChest[nextNum + 1] = 0;sChest[nextNum + 1] = 0;break;
                case 3:dBoots[nextNum + 1] = 0;hBoots[nextNum + 1] = 0;sBoots[nextNum + 1] = 0;break;
            }

            ColorSort(nextNum);
            ColorSort(nextNum + 1);

            ItemImageDisplay(0);
            ItemImageDelete(0);
            ItemImageDelete(1);
            ItemImageDelete(99);
            BenefitCalculate();
            Save();
            im.Rewrite();

            //色戻す
            for(int x=0;x<baseItem.Length;x++){
                baseItem[x].itemImage.color = new Color32 (255, 255, 255, 255);
            }
            Debug.Log(equipOrder);
            baseItem[equipOrder].itemImage.color = new Color32 (255, 192, 192, 255);
        }
    }

    public void ItemImageDisplay(int order){
        int p = 0;
        for(int x = 0;x < baseItem.Length;x++){
            if(baseItemState[x]<0 && windowKind == 0){
                p += 1;
            }
        }

        if(p == 0 || p == 1){
            holdOrder[p] = order;
            detail[p].itemImage.GetComponent<Image>().sprite = weaponImage[baseItemState[order] % 10];
        if(baseItemState[order] / 10 == 1){
            detail[p].itemDetail.text = weaponDetail[baseItemState[order] % 10];
            detail[p].itemName.text = weaponName[baseItemState[order] % 10];
            detail[p].attackValueText.text = aWeapon[order].ToString("");
            detail[p].speedValueText.text = sWeapon[order].ToString("");
        }
        if(baseItemState[order] / 10 == 2){
            detail[p].itemDetail.text = helmetDetail[baseItemState[order] % 10];
            detail[p].itemName.text = armorName[baseItemState[order] % 10];
            detail[p].defenseValueText.text = dHelmet[order].ToString("");
            detail[p].HPValueText.text = hHelmet[order].ToString("");
            detail[p].speedValueText.text = sHelmet[order].ToString("");
        }
        if(baseItemState[order] / 10 == 3){
            detail[p].itemDetail.text = chestDetail[baseItemState[order] % 10];
            detail[p].itemName.text = armorName[baseItemState[order] % 10];
            detail[p].defenseValueText.text = dChest[order].ToString("");
            detail[p].HPValueText.text = hChest[order].ToString("");
            detail[p].speedValueText.text = sChest[order].ToString("");
        }
        if(baseItemState[order] / 10 == 4){
            detail[p].itemDetail.text = bootsDetail[baseItemState[order] % 10];
            detail[p].itemName.text = armorName[baseItemState[order] % 10];
            detail[p].defenseValueText.text = dBoots[order].ToString("");
            detail[p].HPValueText.text = hBoots[order].ToString("");
            detail[p].speedValueText.text = sBoots[order].ToString("");
        }
        }

        if(p==1){
            detail[2].itemImage.GetComponent<Image>().sprite = weaponImage[baseItemState[holdOrder[0]] % 10 * -1];
            if(baseItemState[order] / 10 == 1){
            detail[2].itemDetail.text = weaponDetail[baseItemState[holdOrder[0]] % 10 * -1];
            detail[2].itemName.text = weaponName[baseItemState[holdOrder[0]] % 10 * -1];
            detail[2].attackValueText.text = (aWeapon[holdOrder[0]] + aWeapon[holdOrder[1]]).ToString("");
            detail[2].speedValueText.text = (sWeapon[holdOrder[0]] + sWeapon[holdOrder[1]]).ToString("");
            }
            if(baseItemState[order] / 10 == 2){
            detail[2].itemDetail.text = helmetDetail[baseItemState[holdOrder[0]] % 10 * -1];
            detail[2].itemName.text = armorName[baseItemState[holdOrder[0]] % 10 * -1];
            detail[2].defenseValueText.text = (dHelmet[holdOrder[0]] + dHelmet[holdOrder[1]]).ToString("");
            detail[2].HPValueText.text = (hHelmet[holdOrder[0]] + hHelmet[holdOrder[1]]).ToString("");
            detail[2].speedValueText.text = (sHelmet[holdOrder[0]] + sHelmet[holdOrder[1]]).ToString("");
            }
            if(baseItemState[order] / 10 == 3){
            detail[2].itemDetail.text = chestDetail[baseItemState[holdOrder[0]] % 10 * -1];
            detail[2].itemName.text = armorName[baseItemState[holdOrder[0]] % 10 * -1];
            detail[2].defenseValueText.text = (dChest[holdOrder[0]] + dChest[holdOrder[1]]).ToString("");
            detail[2].HPValueText.text = (hChest[holdOrder[0]] + hChest[holdOrder[1]]).ToString("");
            detail[2].speedValueText.text = (sChest[holdOrder[0]] + sChest[holdOrder[1]]).ToString("");
            }
            if(baseItemState[order] / 10 == 4){
            detail[2].itemDetail.text = bootsDetail[baseItemState[holdOrder[0]] % 10 * -1];
            detail[2].itemName.text = armorName[baseItemState[holdOrder[0]] % 10 * -1];
            detail[2].defenseValueText.text = (dBoots[holdOrder[0]] + dBoots[holdOrder[1]]).ToString("");
            detail[2].HPValueText.text = (hBoots[holdOrder[0]] + hBoots[holdOrder[1]]).ToString("");
            detail[2].speedValueText.text = (sBoots[holdOrder[0]] + sBoots[holdOrder[1]]).ToString("");
            }
        }
    }

    public void ItemImageDelete(int order){
        for(int x=0;x<2;x++){
            if(holdOrder[x] == order && windowKind == 0){
                detail[x].itemImage.GetComponent<Image>().sprite = null;
                detail[x].itemDetail.text = null;
                detail[x].itemName.text = null;
                detail[x].attackValueText.text = null;
                detail[x].defenseValueText.text = null;
                detail[x].HPValueText.text = null;
                detail[x].speedValueText.text = null;
                holdOrder[x] = 0;
            }
        }
        if(order == 99){
            for(int x=0;x<3;x++){
                detail[x].itemImage.GetComponent<Image>().sprite = null;
                detail[x].itemDetail.text = null;
                detail[x].itemName.text = null;
                detail[x].attackValueText.text = null;
                detail[x].defenseValueText.text = null;
                detail[x].HPValueText.text = null;
                detail[x].speedValueText.text = null;
                if(x==0||x==1)holdOrder[x] = 0;
            }
        }
    }

    public void Sale(){
        int backNum = 0;

        BenefitCalculate();
        mm.Sale(benefit);

        for(int x = 0;x < baseItem.Length;x++){
            if(baseItemState[x] == 0){
                baseItem[x].itemImage.sprite = null;
                itemLevel[x] = 0;
                baseItem[x].levelText.text = itemLevel[x].ToString("");
                break;
            }
            if(baseItemState[x] < 0){
                itemLevel[x] = 0;
                baseItem[x].levelText.text = itemLevel[x].ToString("");
                baseItem[x].itemImage.sprite = null;
                backNum += 1;
                baseItemState[x] = 0;
            }
            if(baseItemState[x] > 0 && backNum != 0){
                switch(kind){
                    case 0:aWeapon[x - backNum] = aWeapon[x];sWeapon[x - backNum] = sWeapon[x];break;
                    case 1:dHelmet[x - backNum] = dHelmet[x];hHelmet[x - backNum] = hHelmet[x];sHelmet[x - backNum] = sHelmet[x]; break;
                    case 2:dChest[x - backNum] = dChest[x];hChest[x - backNum] = hChest[x];sChest[x - backNum] = sChest[x]; break;                       
                    case 3:dBoots[x - backNum] = dBoots[x];hBoots[x - backNum] = hBoots[x];sBoots[x - backNum] = sBoots[x]; break;
                }
                itemLevel[x - backNum] = itemLevel[x];
                baseItem[x - backNum].levelText.text = itemLevel[x - backNum].ToString("");
                itemLevel[x] = 0;
                baseItem[x].levelText.text = itemLevel[x].ToString("");

                baseItemState[x - backNum] = baseItemState[x];
                baseItem[x - backNum].itemImage.sprite = weaponImage[baseItemState[x - backNum] % 10];
                baseItem[x].itemImage.sprite = null;
                baseItemState[x] = 0;

                if(equipOrder == x){equipOrder -= backNum;}
            }
        }

        ItemImageDisplay(0);

        //色戻す
        for(int x=0;x<baseItem.Length;x++){
            baseItem[x].itemImage.color = new Color32 (255, 255, 255, 255);
            ColorSort(x);
        }
        if(equipOrder>=0)baseItem[equipOrder].itemImage.color = new Color32 (255, 192, 192, 255);

        Save();
        im.Rewrite();
    }

    public void Equip(){
        int preparedBaseItemNum = 0;
        int instantEquipOrder = -1;
        for(int x = 0;x < baseItem.Length;x++){
            if(baseItemState[x]<0){
                preparedBaseItemNum += 1;
                instantEquipOrder = x;
                baseItemState[x] *= -1;
            }
        }

        //装備
        if(preparedBaseItemNum == 1){
            equipOrder = instantEquipOrder;
            for(int x=0;x<baseItem.Length;x++){
                baseItem[x].itemImage.color = new Color32 (255, 255, 255, 255);
            }
            baseItem[equipOrder].itemImage.color = new Color32 (64, 64, 64, 255);
        }

        switch(kind){
            case 0:PlayerPrefs.SetInt("EquipWeapon",equipOrder);break;
            case 1:PlayerPrefs.SetInt("EquipHelmet",equipOrder);break;
            case 2:PlayerPrefs.SetInt("EquipChest",equipOrder);break;
            case 3:PlayerPrefs.SetInt("EquipBoots",equipOrder);break;
        }

        im.Rewrite();
    }
}
