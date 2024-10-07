using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumping : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInParent<Rigidbody>().AddForce(transform.up * 80, ForceMode.Impulse);
        other.GetComponentInParent<Rigidbody>().AddForce(transform.forward * 10,ForceMode.Impulse);
    }
}
