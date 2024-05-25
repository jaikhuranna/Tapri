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
    
    public SpriteRenderer ground;
    
    private bool canInteract = false;
    private bool canOverhear = false;
    private float distanceWith;
    
    void Start()
    {
        owner = (Owner)FindObjectsOfType(typeof(Owner))[0];
        owner = owner.GetComponent<Owner>();
        ngo = (NGO)FindObjectsOfType(typeof(NGO))[0];
        ngo = ngo.GetComponent<NGO>();
        vasuli = (Vasuli)FindObjectsOfType(typeof(Vasuli))[0];
        vasuli = vasuli.GetComponent<Vasuli>();
    }

    // Update is called once per frame
    void Update()
    {
        var ownerDistance = owner.transform.position - gameObject.transform.position;
        var vasuliDistance = vasuli.transform.position - gameObject.transform.position;
        var NGODistance = ngo.transform.position - gameObject.transform.position;
        float distanceWithowner = ownerDistance.magnitude;
        float distanceWithvasuli = vasuliDistance.magnitude;
        float distanceWithNGO = NGODistance.magnitude;

        distances.Add(distanceWithowner);
        distances.Add(distanceWithvasuli);
        distances.Add(distanceWithNGO);

        minimundistance = distances.Min();
        Debug.Log("minimundistance " + minimundistance);
        int indexofmax = distances.IndexOf(minimundistance);

        if (minimundistance < 0.3)
        {
            ground.color = Color.red;
            canInteract = true;
           
            // TODO: ANIMATE CLOSE THE OVERHEAR PREFAB
        }
        else if (0.3 < minimundistance && minimundistance < 1.4)
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