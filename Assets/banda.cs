using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class banda : MonoBehaviour
{
    [SerializeField]private List<GameObject> ChaiLaUI = new List<GameObject>();
    [SerializeField]private List<GameObject> bande = new List<GameObject>();

    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (bande[i].GetComponentInChildren<Teaslot>().IsUnityNull())
            {
                ChaiLaUI[i].SetActive(true);
            }
            else
            {
                ChaiLaUI[i].SetActive(false);
            }
        }
    }
}
