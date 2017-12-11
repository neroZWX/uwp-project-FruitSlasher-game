using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXIT : MonoBehaviour {
    public Button Exit;
    private void Start()
    {
        getComponet();
        Exit.onClick.AddListener(onPlayClick);
    }
    public void getComponet() {
        Exit = transform.Find("Exit").GetComponent<Button>();
    }
    void onPlayClick() {
        Application.Quit();
    }
    private void OnMouseUpAsButton()
    {
        Application.Quit();
       
    }

    
}
