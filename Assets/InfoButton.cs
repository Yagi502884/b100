using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject infoWindow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){

    }

    void OnMouseEnter(){
        transform.localScale = new Vector3(1.2f,1.2f,1.2f);
        infoWindow.SetActive(true);
    }

    void OnMouseExit(){
        transform.localScale = new Vector3(1f,1f,1f);
        infoWindow.SetActive(false);
    }
}
