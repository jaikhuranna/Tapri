using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Object = System.Object;

public class PlayerHandler : MonoBehaviour
{

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
    private List<Object> interactablesNPCs = new List<Object>();
    private void Start()
    {
        ngodata = ngo.GetComponent<NGO>();
        ownerdata = owner.GetComponent<Owner>();
        vasulidata = vasuli.GetComponent<Vasuli>();

        ngoloc = ngo.transform.position;
        ownerloc = owner.transform.position;
        vasuliloc = vasuli.transform.position;
        
        interactablesNPCs.Add(ngodata);
        interactablesNPCs.Add(ownerdata);
        interactablesNPCs.Add(vasulidata);

        npcsLoactions.Add(ngoloc);
        npcsLoactions.Add(ownerloc);
        npcsLoactions.Add(vasuliloc);
    }

    List<float> Distances()
    {
        List<float> distances = new List<float>() { };
        for (int i = 0; i < 3; i++)
        {
            Vector3 distance = transform.position - npcsLoactions[i];
            distances.Add(Math.Abs(distance.magnitude));
        }
        return distances;
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
        var currentInteractable = interactablesNPCs[Closestto()]; 
        Debug.Log(interactablesNPCs[Closestto()]);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentInteractable == ngodata && ngodata.i < 4)
            {
                ngodata.i++;
                if (ngodata.i >= 4)
                {
                    dialogHandler.CloseDialog();
                }
                dialogHandler.Dialog(ngodata.dialogs[ngodata.i], ngodata.charintexes[ngodata.i], ngodata.emoindexes[ngodata.i]);
            }
            else if (currentInteractable == ownerdata && ownerdata.i < 4)
            {
                ownerdata.i++;
                if (ownerdata.i >= 4)
                {
                    dialogHandler.CloseDialog();
                }
                dialogHandler.Dialog(ownerdata.dialogs[ownerdata.i], ownerdata.charintexes[ownerdata.i], ownerdata.emoindexes[ownerdata.i]);
            }
            else if (currentInteractable == vasulidata && vasulidata.i < 4)
            {
                vasulidata.i++;
                if (vasulidata.i >= 4)
                {
                    dialogHandler.CloseDialog();
                }
                dialogHandler.Dialog(vasulidata.dialogs[vasulidata.i], vasulidata.charintexes[vasulidata.i], vasulidata.emoindexes[vasulidata.i]);
            }
        }
    }
}