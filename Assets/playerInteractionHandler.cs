using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHandler : MonoBehaviour
{
    private int i = -1;
    
    public DialogHandler dialogHandler;
    public GameObject ngo;

    private NGO ngodata;
    private void Start()
    {
        ngodata = ngo.GetComponent<NGO>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && i < 4 )
        {
            i++;
            dialogHandler.Dialog(ngodata.dialogs[i], ngodata.charintexes[i], ngodata.emoindexes[i]);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && i == 4)
        {
            dialogHandler.CloseDialog();        
        }
    }
}