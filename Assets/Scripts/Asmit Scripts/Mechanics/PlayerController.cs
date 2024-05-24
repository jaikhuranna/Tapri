using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerControl : MonoBehaviour
{
    public GameObject teaCup;
    public GameObject teaSlot;
    public GameObject parleG;
    public GameObject parleGSlot;
    public GameObject arm;

    public CharacterController controller;
    
    private bool isInFrontOfStall;
    private bool isInFrontOfTable;

    private int numberOfItemsInHand = 0;
    
    // public Rigidbody playerRb;

    
    
    public float speed = 40.0f;
    public GameObject[] itemsInHand;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0,0 );
        } 
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.rotation = new Quaternion(0, 180, 0,0 );
        }

        if (isInFrontOfStall == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                teaCup.transform.parent = gameObject.transform;
                teaCup.transform.position = new Vector3(arm.transform.position.x,
                    arm.transform.position.y+0.1f, arm.transform.position.z);
                numberOfItemsInHand++;
            }
           
            if (numberOfItemsInHand == 1 && Input.GetKeyDown(KeyCode.E))
            {
                parleG.transform.parent = gameObject.transform;
                parleG.transform.position = new Vector3(arm.transform.position.x,
                    arm.transform.position.y+0.1f, arm.transform.position.z);
                numberOfItemsInHand++;
            }
        }
        else if (isInFrontOfTable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                teaCup.transform.parent = teaSlot.transform;
                teaCup.transform.position = new Vector3(teaSlot.transform.position.x,
                    teaSlot.transform.position.y, teaSlot.transform.position.z);
                numberOfItemsInHand--;
            }
           
            if (numberOfItemsInHand == 1 && Input.GetKeyDown(KeyCode.E))
            {
                parleG.transform.parent = parleGSlot.transform;
                parleG.transform.position = new Vector3(parleGSlot.transform.position.x,
                    parleGSlot.transform.position.y+0.1f, parleGSlot.transform.position.z);
                numberOfItemsInHand--;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered Collider");
        Debug.Log(other.name);
        if (other.name == "Stall")
        {
            isInFrontOfStall = true;
        }
        else if (other.name == "Table")
        {
            isInFrontOfTable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Stall")
        {
            isInFrontOfStall = false;
        }
        else if (other.name == "Table")
        {
            isInFrontOfTable = false;
        }
    }
}
