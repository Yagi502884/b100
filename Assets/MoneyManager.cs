using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int[] cost;
    public int money;

    public int[] synthesisCount = {0,0,0,0};

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI[] costText;

    void Start()
    {

        Debug.Log("startauydefa");
        money = PlayerPrefs.GetInt("Money",0);
        moneyText.text = money.ToString("");
        for(int x = 0;x<synthesisCount.Length;x++){
            synthesisCount[x] = PlayerPrefs.GetInt("SynthesisCount" + x,0);
            cost[x] = Mathf.FloorToInt(10 * Mathf.Pow(1.3f,synthesisCount[x]));
            costText[x].text = cost[x].ToString("");
            Debug.Log("x" + x);
        }
    }

    void Update()
    {
        
    }

    public void Buy(int kind){
        money -= cost[kind];
        synthesisCount[kind] += 1;
        moneyText.text = money.ToString("");
        cost[kind] = Mathf.FloorToInt(10 * Mathf.Pow(1.3f,synthesisCount[kind]));
        costText[kind].text = cost[kind].ToString("");
        PlayerPrefs.SetInt("SynthesisCount" + kind,synthesisCount[kind]);
    }

    public void Sale(int benefit){
        money += benefit;
        moneyText.text = money.ToString("");
        PlayerPrefs.SetInt("Money",money);
    }
}
