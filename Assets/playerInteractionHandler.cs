using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Object = System.Object;

public class PlayerHandler : MonoBehaviour
{
    private int i = -1;
    
    public DialogHandler dialogHandler;
    public GameObject ngo;
    public GameObject owner;
    public GameObject vasuli;

    private List<string> Names = new List<string>() {"Ngo", "Owner", "Vasuli"};
    
    private NGO ngodata;
    private Owner ownerdata;
    private Vasuli vasulidata;

    private Vector3 ngoloc;
    private Vector3 ownerloc;
    private Vector3 vasuliloc;

    private List<Vector3> npcsLoactions = new List<Vector3>();
    private Object[] interactablesNPCs = new Object[] {};
    private void Start()
    {
        ngodata = ngo.GetComponent<NGO>();
        ownerdata = owner.GetComponent<Owner>();
        vasulidata = vasuli.GetComponent<Vasuli>();

        ngoloc = ngo.transform.position;
        ownerloc = owner.transform.position;
        vasuliloc = vasuli.transform.position;
        
        interactablesNPCs.Append(ngodata);
        interactablesNPCs.Append(ownerdata);
        interactablesNPCs.Append(vasulidata);

        npcsLoactions.Add(ngoloc);
        npcsLoactions.Add(ownerloc);
        npcsLoactions.Add(vasuliloc);
    }

    int Closestto()
    {
        List<float> distances = new List<float>() { };
        for (int i = 0; i < 3; i++)
        {
            Vector3 distance = transform.position - npcsLoactions[i];
            distances.Add(Math.Abs(distance.magnitude));
        }
        int index = distances.IndexOf(distances.Min());
    return index;
    }

    void Update()
    {
        Debug.Log(Names[Closestto()]);
        // Debug.Log(interactablesNPCs[Closestto()]);
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