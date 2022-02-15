using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pollitos : MonoBehaviour {
    public Transform point1;
    public Transform point2;
    public bool pos = true;
    private NavMeshAgent agent;
    private Animator animator;
    private Vector3 movimiento;


    void Start () {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        animator = GetComponent<Animator>();
        
        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Set the agent to go to the currently selected destination.
        if (pos) {
            agent.destination = point1.position;
        }else {
            agent.destination = point2.position;
        }
    }


    void Update () {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
            if (pos)
            {
                pos = false;
            }
            else
            {
                pos = true;
            }
        }
        
        if (movimiento != Vector3.zero)

        {
            animator.SetBool("Run", true);

        }
        else
        {

            animator.SetBool("Run", false);

        }
    }
}
