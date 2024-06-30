using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UnityEngine;

public class PullRackScript : MonoBehaviour
{
    // Start is called before the first frame update

    Collider rackCollider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("canPickUp"))
        {
            other.transform.position = this.transform.position;
        }
    }
}
