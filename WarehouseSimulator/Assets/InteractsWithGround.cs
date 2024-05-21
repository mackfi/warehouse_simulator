using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractsWithGround : MonoBehaviour
{
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.layer == 6)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.position = (new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z));
        }
    }

    //void OnColl
}
