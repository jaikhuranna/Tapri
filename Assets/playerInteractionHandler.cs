using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int i = -1;
    public DialogHandler dialogHandler;
    public Owner owner;
    void Start()
    {
        owner = (Owner)FindObjectsOfType(typeof(Owner))[0];
        owner = owner.GetComponent<Owner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && i < 4)
        {
            i++;
            dialogHandler.Dialog(owner.dialogs[i], owner.charintexes[i], owner.emoindexes[i]);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && i == 4)
        {
            dialogHandler.CloseDialog();        
        }
    }
}