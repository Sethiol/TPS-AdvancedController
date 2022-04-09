using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AILocomotion : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    NavMeshAgent agent;
    Animator animator;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTime;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            float distance = (PlayerTransform.position - agent.destination).sqrMagnitude;
            if(distance > maxDistance*maxDistance)
            {
                agent.destination = PlayerTransform.position;
            }
            timer = maxTime;
        }
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
