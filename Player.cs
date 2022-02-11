using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    NavMeshAgent agente;
    [SerializeField] public Transform of;
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
        transform.position = of.position;
        movimiento = agente.velocity;
        if(Input.GetKey(KeyCode.UpArrow))
            agente.SetDestination(of.position+Vector3.forward);
        if(Input.GetKey(KeyCode.LeftArrow))
            agente.SetDestination(of.position+Vector3.left);
        if(Input.GetKey(KeyCode.RightArrow))
            agente.SetDestination(of.position+Vector3.right);
        if(Input.GetKey(KeyCode.DownArrow))
            agente.SetDestination(of.position+Vector3.back);
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