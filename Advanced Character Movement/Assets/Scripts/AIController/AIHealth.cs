using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    Ragdoll ragdoll;
    SkinnedMeshRenderer[] skinnedMeshRenderer;
    public float blinkIntensity;
    public float blinkDuration;
    float blinkTimer;
    // Start is called before the first frame update
    void Start()
    {
        skinnedMeshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();
        ragdoll = GetComponent<Ragdoll>();
        currentHealth = maxHealth;
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach(var rigidBody in rigidBodies)
        {
           HitBox hitBox = rigidBody.gameObject.AddComponent<HitBox>();
           hitBox.health = this;
        }
        
    }
    public void TakeDamage(float amount, Vector3 direction)
    {
        currentHealth -= amount;
        if(currentHealth <= 0.0f)
        {
            Die();
        }
        blinkTimer = blinkDuration;
    }
    private void Die()
    {
        ragdoll.ActivateRagdoll();
    }
    private void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        //skinnedMeshRenderer[0].material.color = Color.white * intensity;
        //skinnedMeshRenderer[1].material.color = Color.white * intensity;
    }
}
