using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask selectionPointLayer;
    public GameObject itemSnap;
    RaycastHit hit;
    private bool temp = true;
    private bool holdingItem = false;
    private GameObject heldItem;

    //selectables
    public GameObject computer, calendar, door, build1, build2;

    // Update is called once per frame
    void Update()
    {
        //debug draw rays with their colours
        if(temp)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.green);
        }

        if(!temp)
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.blue);
        }



        //pickup item and raycast
        if(Input.GetKeyDown("e"))
        {
            if(!holdingItem)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, selectionPointLayer))
                {

                    //colour debug
                    temp = false;
                    Debug.Log("Did Hit");
                    Invoke("ColourReset", 1f);

                    //picks up the item
                    if(hit.transform.tag == "Moveable")
                    {
                        heldItem = hit.transform.gameObject;
                        holdingItem = true;
                    }
                }
            }
            else
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, selectionPointLayer))
                {
                    //colour debug
                    temp = false;
                    Debug.Log("Did Hit");
                    Invoke("ColourReset", 1f);
                    
                    //moves the item to the snap point
                    if(hit.transform.tag == "SnapPoint")
                    {
                        holdingItem = false;
                        heldItem.transform.position = hit.transform.position;
                    }
                }
            }
        }
        if(Input.GetMouseButtonDown(0))
        {
            if(!holdingItem)
            {
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10f, selectionPointLayer))
                {
                    //opens the required ui
                    if(hit.transform.tag == "Computer")
                    {
                        computer.SetActive(true);
                    }
                    //opens the required ui
                    if(hit.transform.tag == "Calendar")
                    {
                        calendar.SetActive(true);
                    }
                    //opens the required ui
                    if(hit.transform.tag == "Build1")
                    {
                        build1.SetActive(true);
                    }
                    //opens the required ui
                    if(hit.transform.tag == "Build2")
                    {
                        build2.SetActive(true);
                    }
                    //opens the required ui
                    if(hit.transform.tag == "Door")
                    {
                        door.SetActive(true);
                    }
                }
            }
        }

        //move item to the players snap point
        if(holdingItem)
        {
            heldItem.transform.position = itemSnap.transform.position;
        }
    }

    //reset the debug colour
    void ColourReset(){
        temp = true;
    }
}
