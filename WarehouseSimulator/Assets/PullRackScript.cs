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
        rackCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("canPickUp"))
        {
            var otherRb = other.GetComponent<Rigidbody>();
            otherRb.velocity = Vector3.zero;
            otherRb.freezeRotation = true;
            otherRb.rotation = Quaternion.identity;
            /*var gridY = other.transform.position.y - (rackCollider.transform.position.y - rackCollider.bounds.size.y / 2);
            var gridZ = other.transform.position.z - (rackCollider.transform.position.z - rackCollider.bounds.size.z / 2);
            var newY = other.transform.position.y - (mod(gridY, rackCollider.bounds.size.y / 3)) + (rackCollider.bounds.size.y / 3) * 0.5f;
            var newZ = other.transform.position.z - (mod(gridZ, rackCollider.bounds.size.z / 3)) + (rackCollider.bounds.size.z / 3) * 0.5f;*/
            other.transform.position = new Vector3(this.transform.position.x, other.transform.position.y, other.transform.position.z);
        }
    }

    float mod(float x, float m)
    {
        return (x % m + m) % m;
    }
}
