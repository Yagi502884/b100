using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdventureButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown(){
        SceneManager.LoadScene("Dungeon");
        Debug.Log("PUSH");
        transform.localScale = new Vector3(1f,1f,1f);
    }

    void OnMouseEnter(){
        transform.localScale = new Vector3(1.2f,1.2f,1.2f);
    }

    void OnMouseExit(){
        transform.localScale = new Vector3(1f,1f,1f);
    }
}
