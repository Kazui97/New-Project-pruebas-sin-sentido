using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // variables para gestionar la vision y velocidad 
    public float vision;
    public float speed;

    //variables para guardar el jugador 
    GameObject player;

    Vector3 posicioninicial;

    void Start()
    {
        //recuperamos al jugador gracias al tag
        player = GameObject.FindGameObjectWithTag("Player");
        //guardamos la posicion inicial 
        posicioninicial = transform.position;
    }

   
    void Update()
    {
        // por defecto nuestro objeto siempre sera la posicion incial 
        Vector3 target = posicioninicial;

        // pero si la distancia hasta el jugador es menor que el radio de vision de objetivo sera el 
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < vision) target = player.transform.position;

        // finalmente movemos el enemigo en direccion a su target
        float fixedspeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedspeed);
        
        //podemos debugearlo con una linea
        Debug.DrawLine(transform.position, target, Color.green);
    }

    //podemos dibujar el radio de vision sobre la escena 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, vision);
    }
}
