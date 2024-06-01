using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class laptopUIScript : MonoBehaviour
{
    public float interactRange = 5f;

    public Canvas playerCanvas;
    public Canvas laptopCanvas;

    private bool laptopEnabled = false;

    //public PlayerMovementTutorial movementScript;

    // Start is called before the first frame update
    void Start()
    {
        laptopCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, interactRange))
                {
                    if (hit.transform.gameObject.tag == "laptop" && !laptopEnabled)
                    {
                        UnityEngine.Cursor.lockState = CursorLockMode.None;
                        UnityEngine.Cursor.visible = true;
                        playerCanvas.enabled = false;
                        laptopCanvas.enabled = true;
                        //laptopEnabled = true;
                        //movementScript.horizontalInput = 0f;
                        //movementScript.verticalInput = 0f;
                    }
                }
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;
            playerCanvas.enabled = true;
            laptopCanvas.enabled = false;
        }

    }
}
