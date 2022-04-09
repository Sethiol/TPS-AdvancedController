using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigidbodies;
    Animator animator;
    private void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    public void DeactivateRagdoll()
    {
        foreach(var Rigidbody in rigidbodies)
        {
            Rigidbody.isKinematic = true;
        }
        animator.enabled = true;
    }
    public void ActivateRagdoll()
    {
        foreach (var Rigidbody in rigidbodies)
        {
            Rigidbody.isKinematic = false;
        }
        animator.enabled = false;
    }
}
