using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour {

    //Variable para el tiempo transcurrido (pública porque la necesitaremos más adelante en Jugador Controller)
    public float tiempo = 0.0f;

    //Variable para asociar el objeto Texto Tiempo
    public Text textoTiempo;

    //Variables Jugador y JugadorController para obtener isTiempo
    public GameObject jugador;
    Player jugadorController;

    void Start () {

        //Inicializo el texto del contador de tiempo
        textoTiempo.text = "Tiempo: 00:00";

        //Capturo el componente JugadorController de jugador
        jugadorController = jugador.GetComponent<Player>();
		
    }
	
    void Update () {

        //Escribo tiempo transcurrido (si no se ha acabado el juego)
        if (jugadorController.isTiempo){
            textoTiempo.text = "Tiempo: " + formatearTiempo();
        }
		
    }

    //Formatear tiempo (público porque la necesitaremos más adelante en Jugador Controller)
    public string formatearTiempo(){

        //Añado el intervalo transcurrido a la variable tiempo
        if (jugadorController.isTiempo){
            tiempo += Time.deltaTime;
        }	
    
        //Formateo minutos y segundos a dos dígitos
        string minutos = Mathf.Floor(tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(tiempo % 60).ToString("00");
    
        //Devuelvo el string formateado con : como separador
        return minutos + ":" + segundos;

    }
}