using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class laptopUIScript : MonoBehaviour
{
    public float interactRange = 5f;

    public Canvas playerCanvas;
    public Canvas laptopCanvas;

    private bool laptopEnabled = false;

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
                        playerCanvas.enabled = false;
                        laptopCanvas.enabled = true;
                        //laptopEnabled = true;
                    }
                }
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerCanvas.enabled = true;
            laptopCanvas.enabled = false;
        }

    }
}
