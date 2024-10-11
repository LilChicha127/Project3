using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RagdollLogic : MonoBehaviour
{
    public List<Rigidbody> rigidbodies;
    public List<Collider> colliders;

    private void Start()
    {
        rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>());
        colliders = new List<Collider>(GetComponentsInChildren<Collider>());
        Ragdoll(true);
    }
    public void Ragdoll(bool isKinematic)
    {
        foreach(Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = isKinematic;
            
        }
    }
    public void Colliders()
    {
        foreach (Collider cl in colliders)
        {
            cl.excludeLayers = 6;

        }
    }
}
