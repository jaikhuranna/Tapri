using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHandler : MonoBehaviour
{
    public DialogHandler dialogHandler;
    public Owner owner;
    public NGO ngo;
    public Vasuli vasuli;
    private List<float> distances;
    private float minimundistance;

    private float ownerDistance;
    private float vasuliDistance;
    private float NGODistance;
    public GameObject gameownder;
    public GameObject gamevasuli; 
    public GameObject gamengo;

    private Transform owndertrans;
    private Transform vasulitrans;
    private Transform ngotrans;
    
    public SpriteRenderer ground;
    
    private bool canInteract = false;
    private bool canOverhear = false;
    private float distanceWith;

    private float distanceWithowner = 20; 
    private float distanceWithvasuli = 20;
    private float distanceWithNGO = 20;

    private void Start()
    {
        owndertrans = gameownder.transform;
        vasulitrans = gamevasuli.transform;
        ngotrans = gamengo.transform;

    }

    void Update()
    {
        ownerDistance = owndertrans.position.x - gameObject.transform.position.x;
        vasuliDistance = vasulitrans.position.x - gameObject.transform.position.x;
        NGODistance = ngotrans.position.x - gameObject.transform.position.x;
        // float distanceWithowner = ownerDistance.magnitude;
        // float distanceWithvasuli = vasuliDistance.magnitude;
        // float distanceWithNGO = NGODistance.magnitude;
        Debug.Log(ownerDistance);
        distances.Add(ownerDistance);
        distances.Add(vasuliDistance);
        distances.Add(NGODistance);

        minimundistance = distances.Min();
        Debug.Log("minimundistance " + minimundistance);
        int indexofmax = distances.IndexOf(minimundistance);

        if (minimundistance < 2.5)
        {
            ground.color = Color.red;
            canInteract = true;
           
            // TODO: ANIMATE CLOSE THE OVERHEAR PREFAB
        }
        else if (2.5 < minimundistance && minimundistance < 15)
        {
            ground.color = Color.yellow;
            canOverhear = true;
           
            dialogHandler.CloseDialog();
        }
        else
        {
            ground.color = Color.white;
            canInteract = false;
            canOverhear = false;
           
           // TODO: CLOSE OVERHEAR BUBBLE 
           dialogHandler.CloseDialog();
        }
        switch (indexofmax)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Space) && owner.i < 4 && canInteract == true)
                {
                    owner.i++;
                    dialogHandler.Dialog(owner.dialogs[owner.i], owner.charintexes[owner.i], owner.emoindexes[owner.i]);
                }
                else if (Input.GetKeyUp(KeyCode.Space) && owner.i == 4)
                {
                    dialogHandler.CloseDialog();        
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.Space) && vasuli.i < 4 && canInteract == true)
                {
                    vasuli.i++;
                    dialogHandler.Dialog(vasuli.dialogs[vasuli.i], vasuli.charintexes[vasuli.i], vasuli.emoindexes[vasuli.i]);
                }
                else if (Input.GetKeyUp(KeyCode.Space) && vasuli.i == 4)
                {
                    dialogHandler.CloseDialog();        
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Space) && ngo.i < 4 && canInteract == true)
                {
                    ngo.i++;
                    dialogHandler.Dialog(ngo.dialogs[ngo.i], ngo.charintexes[ngo.i], ngo.emoindexes[ngo.i]);
                }
                else if (Input.GetKeyUp(KeyCode.Space) && ngo.i == 4)
                {
                    dialogHandler.CloseDialog();        
                }
                break;
        }
        distances.Clear();
        
    }
}