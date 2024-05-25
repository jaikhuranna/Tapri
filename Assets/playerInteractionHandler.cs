using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Object = System.Object;

public class PlayerHandler : MonoBehaviour
{
    public DialogHandler dialogHandler;
    public GameObject ngo;
    public GameObject owner;
    public GameObject vasuli;
    public GameObject player;

    private List<string> Names = new List<string>() {"Ngo", "Owner", "Vasuli", ""};
    
    private NGO ngodata;
    private Owner ownerdata;
    private Vasuli vasulidata;
    private Player playerdata;

    private Vector3 ngoloc;
    private Vector3 ownerloc;
    private Vector3 vasuliloc;
    private Vector3 playerloc;

    public bool PlayerMonologe = true;
    private List<Vector3> npcsLoactions = new List<Vector3>();
    private List<Object> interactablesNPCs = new List<Object>();
    private void Start()
    {
        ngodata = ngo.GetComponent<NGO>();
        ownerdata = owner.GetComponent<Owner>();
        vasulidata = vasuli.GetComponent<Vasuli>();
        playerdata = player.GetComponent<Player>();

        ngoloc = ngo.transform.position;
        ownerloc = owner.transform.position;
        vasuliloc = vasuli.transform.position;
        playerloc = player.transform.position;
        
        interactablesNPCs.Add(ngodata);
        interactablesNPCs.Add(ownerdata);
        interactablesNPCs.Add(vasulidata);
        interactablesNPCs.Add(playerdata);

        npcsLoactions.Add(ngoloc);
        npcsLoactions.Add(ownerloc);
        npcsLoactions.Add(vasuliloc);
        npcsLoactions.Add(playerloc);
    }

    List<float> Distances()
    {
        List<float> distances = new List<float>() { };
        for (int i = 0; i < 4; i++)
        {
            Vector3 distance = transform.position - npcsLoactions[i];
            distances.Add(Math.Abs(distance.magnitude));
        }
        return distances;
    }

    int Closestto()
    {
        int index = Distances().IndexOf(Distances().Min());
    return index;
    }

    void CheckdistanceandStatus()
    {
        if (Distances().Min() > 6)
        {
            dialogHandler.CloseDialog();
        }
    }

    void Update()
    {
        var currentInteractable = interactablesNPCs[Closestto()]; 
        CheckdistanceandStatus();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentInteractable == playerdata && PlayerMonologe == true)
            {
                playerdata.i++;
                Debug.Log(playerdata.i);
                if (playerdata.i == 3 )
                {
                    dialogHandler.CloseDialog();
                    SceneManager.LoadScene(3);
                } 
                dialogHandler.Dialog(playerdata.dialogs[playerdata.i], playerdata.charintexes[playerdata.i], playerdata.emoindexes[playerdata.i]); }
            else if (currentInteractable == ngodata && ngodata.i < 1)
            {
                ngodata.i++;
                if (ngodata.i >= 1)
                {
                    dialogHandler.CloseDialog();
                }
                dialogHandler.Dialog(ngodata.dialogs[ngodata.i], ngodata.charintexes[ngodata.i], ngodata.emoindexes[ngodata.i]);
            }
            else if (currentInteractable == ownerdata && ownerdata.i < 9)
            {
                ownerdata.i++;
                if (ownerdata.i >= 9)
                {
                    dialogHandler.CloseDialog();
                }
                dialogHandler.Dialog(ownerdata.dialogs[ownerdata.i], ownerdata.charintexes[ownerdata.i], ownerdata.emoindexes[ownerdata.i]);
            }
            else if (currentInteractable == vasulidata && vasulidata.i < 2)
            {
                vasulidata.i++;
                if (vasulidata.i >= 2)
                {
                    dialogHandler.CloseDialog();
                }
                dialogHandler.Dialog(vasulidata.dialogs[vasulidata.i], vasulidata.charintexes[vasulidata.i], vasulidata.emoindexes[vasulidata.i]);
            }
        }
    }
}