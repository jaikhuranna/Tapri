using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int i = -1;
    public DialogHandler dialogHandler;
    public Owner owner;
    public SpriteRenderer ground;

    private bool canInteract = false;
    private bool canOverhear = false;
    private float distanceWith;
    void Start()
    {
        owner = (Owner)FindObjectsOfType(typeof(Owner))[0];
        owner = owner.GetComponent<Owner>();
    }

    // Update is called once per frame
    void Update()
    {
        var distancevector = owner.transform.position - gameObject.transform.position;
        distanceWith = distancevector.magnitude;
        
        if (distanceWith < 0.3)
        {
           ground.color = Color.red;
           canInteract = true;
        }
        else if (0.3 < distanceWith && distanceWith < 1.4)
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
           
           dialogHandler.CloseDialog();
        }
        if (Input.GetKeyDown(KeyCode.Space) && i < 4 && canInteract == true)
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