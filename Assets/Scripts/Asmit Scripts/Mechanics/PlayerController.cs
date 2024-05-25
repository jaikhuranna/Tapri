using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerControl : MonoBehaviour
{
    public GameObject teaCup;
    public GameObject teaSlot;
    public GameObject teaSlot1;
    public GameObject teaSlot2;
    public GameObject parleG;
    public GameObject parleGSlot;
    public GameObject arm;
    public GameObject cameraObj;

    public Animator animator;

    public CharacterController controller;
    
    private bool isInFrontOfStall;
    private bool isInFrontOfTable;
    private bool isInFrontOfTable1;
    private bool isInFrontOfTable2;

    private int numberOfItemsInHand = 0;
    
    // public Rigidbody playerRb;

    public List<Transform> Teaslots = new List<Transform>();
    
    public float speed = 40.0f;
    public GameObject[] itemsInHand;

    private void Start()
    {
       Teaslots.Add(teaSlot.transform);
       Teaslots.Add(teaSlot1.transform);
       Teaslots.Add(teaSlot2.transform);
       
    }

    private void Update()
    {
        Debug.Log("table  " + isInFrontOfTable);
        Debug.Log("table 1 " + isInFrontOfTable1);
        Debug.Log("table 2 " + isInFrontOfTable2);
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0f, 0f);
        float horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Math.Abs(horizontalMove));
        
        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.rotation = new Quaternion(0, 180, 0,0 );
        } 
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.rotation = new Quaternion(0, 0, 0,0 );
        }

        if (isInFrontOfStall == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                teaCup.transform.parent = gameObject.transform;
                teaCup.transform.position = new Vector3(arm.transform.position.x,
                    arm.transform.position.y+0.1f, arm.transform.position.z);
                numberOfItemsInHand++;
                teaCup.transform.localScale = Vector3.one * 2.5f;
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
        else if (isInFrontOfTable1 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                teaCup.transform.parent = teaSlot1.transform;
                teaCup.transform.position = new Vector3(teaSlot1.transform.position.x,
                    teaSlot1.transform.position.y, teaSlot1.transform.position.z);
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
        else if (isInFrontOfTable2 == true)
        {
            Debug.Log(teaSlot2.transform.position);
            if (Input.GetKeyDown(KeyCode.E))
            {
                teaCup.transform.parent = teaSlot2.transform;
                teaCup.transform.position = new Vector3(teaSlot2.transform.position.x,
                    teaSlot2.transform.position.y, teaSlot2.transform.position.z);
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
        else if (other.name == "Table (1)")
        {
            isInFrontOfTable1 = true;
        }
        else if (other.name == "Table (2)")
        {
            isInFrontOfTable2 = true;
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
        else if (other.name == "Table (1)")
        {
            isInFrontOfTable1 = false;
        }
        else if (other.name == "Table (2)")
        {
            isInFrontOfTable2 = false;
        }
    }
}