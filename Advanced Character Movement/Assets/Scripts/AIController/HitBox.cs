using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public AIHealth health;
    public void OnRaycastHit(GunController weapon, Vector3 direction)
    {
        health.TakeDamage(weapon.Damage, direction);
    }
}
