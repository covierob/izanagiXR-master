using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelList : MonoBehaviour
{
    [SerializeField] private List<GameObject> itemList;
    [SerializeField] private GameObject menu;

    public void ActivateObjects()
    {
        foreach (GameObject item in itemList)
        {
            item.SetActive(true);
            menu.SetActive(false);
        }
    }
}
