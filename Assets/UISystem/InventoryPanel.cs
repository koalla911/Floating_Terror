using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    public GameObject Panel;

    private void Start() 
    {
        Panel.SetActive(false);

    }

    private void Update() 
    {
        OpenPanel();
    }

    public void OpenPanel() 
    {
        
        if ( Input.GetKeyDown(KeyCode.F))
        {
            Panel.SetActive(true);
        }

        if ( Input.GetKeyDown(KeyCode.R))
        {
            Panel.SetActive(false);
        }
    

    }
}
