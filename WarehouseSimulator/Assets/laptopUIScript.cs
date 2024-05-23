using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class laptopUIScript : MonoBehaviour
{
    public float interactRange = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
                //perform raycast to check if player is looking at object within pickuprange
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange))
                {
                    if (hit.transform.gameObject.tag == "laptop")
                    {
                    Console.WriteLine("LAPTOP CLICKED");
                    }
                }
            
        }

    }
}
