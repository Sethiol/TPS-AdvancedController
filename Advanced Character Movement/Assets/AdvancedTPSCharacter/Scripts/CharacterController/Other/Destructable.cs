using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject ReplacementObject;
    GameObject obj;
    public void DestroyAndReplace()
    {
        if (obj) return;
        obj = Instantiate(ReplacementObject, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
