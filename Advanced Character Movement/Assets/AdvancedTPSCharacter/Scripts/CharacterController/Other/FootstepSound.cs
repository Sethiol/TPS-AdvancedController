using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    [SerializeField]
    private Collider FootCollider;
    [SerializeField]
    private AudioSource footstep;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("true");
        if(collision.collider.gameObject.layer == 11)
        {
            Debug.Log("etrue");
            footstep.Play();
        }
    }
}
