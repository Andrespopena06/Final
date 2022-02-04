using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    NavMeshAgent agente;
    private Animator animator;
    private Vector3 movimiento;
    void Start()
    {
        //Capturamos el componente agente del jugador
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movimiento = agente.velocity;
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(rayo, out hit, 100))
            {
                agente.SetDestination(hit.point);
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
