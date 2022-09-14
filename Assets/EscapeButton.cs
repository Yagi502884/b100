using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeButton : MonoBehaviour
{
    public EnemyManager em;
    Vector3 startSize;

    void Start()
    {
        startSize = transform.localScale;
    }

    void Update()
    {
        
    }

    void OnMouseDown(){
        int preMoney = PlayerPrefs.GetInt("Money",0);
        PlayerPrefs.SetInt("Money",em.money + preMoney);
        transform.localScale = startSize;
        SceneManager.LoadScene("inventory2");
    }

    void OnMouseEnter(){
        transform.localScale = startSize * 1.1f;
    }

    void OnMouseExit(){
        transform.localScale = startSize;
    }
}
