using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Destruir el disparo a los 3 segundos
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destruir si alcanza a un enemigo
        if (other.gameObject.CompareTag("Enemigo"))
        {
            //Destruyo al enemigo
            Destroy(other.gameObject);
            
            //Destruyo el disparo
            Destroy(gameObject);
        }
    }
}
