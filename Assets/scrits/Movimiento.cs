using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // variable para gestionar la velocidad 
    public float speed;
    // variable para establecer un punto de destino
    Vector3 destino;
    void Start()
    {
        //inicialmente el punto de destino de la posicion actual
        destino = transform.position;
    }

   
    void Update()
    {
        //detectamos cuando hacemos clic 
        if (Input.GetMouseButtonDown(0))
        {
            //buscamos la posicion del clic respecto a la escena
            destino = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //establecemos la z en cero para que no modifique la profundidad  
            destino.z = 0f;
        }
        //movemos el objeto hacia el punto de destino a una velocidad rectificada
        transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);
        //debugea una linea con el trayecto a recorer
        Debug.DrawLine(transform.position, destino, Color.green);

    }
}
