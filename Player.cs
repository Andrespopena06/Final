using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    NavMeshAgent agente;
    public float velocidad = 10;
    public Transform of;
    private Animator animator;
    private Vector3 movimiento;
    //Variable para comprobar si debo seguir incrementando el tiempo transcurrido
    public bool isTiempo = true;
    //Variable para el número de vidas
    private int vidas = 0;
    public Text Vidas;
    //variable para la posición inicial del jugador
    private Vector3 posicionInicial;

    void Start()
    {
        Vidas.text = "Vidas: " + vidas;
        //Capturo la posición inicial del jugador para cuando pierda una vida poder reposicionarlo
        posicionInicial = transform.position;
        //Capturamos el componente agente del jugador
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        of = GetComponent<Transform>();
    }

    void Update()
    {
        
        
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        //Genero el vector de movimiento
        Vector3 movimiento = new Vector3(movimientoH, 0, movimientoV);

        //Muevo el jugador
        transform.position += movimiento * velocidad * Time.deltaTime;
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
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimiento), 0.15f);
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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);

        if (other.gameObject.CompareTag("Pollitos"))
        {

            //Desactivo el objeto
            other.gameObject.SetActive(false);

            //Decremento el contador de monedas en uno (también se puede hacer como monedas = monedas -1)
            vidas++;

            //Actualizo el texto del contador de monedas
            Vidas.text = "Vidas: " + vidas;

        }

        void quitarVida()
        {

            //Resto una vida
            vidas--;
            //Actualizo el contador de vidas
            Vidas.text = "Vidas: " + vidas;
            //Devuelvo el Jugador a su posición inicial y le quito la fuerza
            transform.position = posicionInicial;
        }
    }
}