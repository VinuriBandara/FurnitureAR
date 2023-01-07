using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangeMenu : MonoBehaviour
{
    public GameObject MainControls;
    public GameObject changeMats;
    public GameObject defaultDisplayed;
    public GameObject deleteControls;
    public GameObject ghostObj;
    public GameObject placementIndicator;
    public bool isMenuDisplayed = true;
    void Start()
    {
    }
    
    public void SetMenu()
    {
        UpdateMenu(MainControls);
    }

    public void SetDelete()
    {
         UpdateMenu(deleteControls);
    }

    public void SetColor()
    {
         UpdateMenu(changeMats);
    }
    
    private void  UpdateMenu(GameObject menu)
    {
        if (defaultDisplayed == MainControls)
        {
            Destroy(ghostObj);
            placementIndicator.SetActive(false);
        }
        
        if (defaultDisplayed != menu)
        {
            defaultDisplayed.SetActive(false);
            menu.SetActive(true);
            defaultDisplayed = menu;
            isMenuDisplayed = true;
        }
        else
        {
            defaultDisplayed.SetActive(!isMenuDisplayed);
            isMenuDisplayed = !isMenuDisplayed;
        }
    }
}
