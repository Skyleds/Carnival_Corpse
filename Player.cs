using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // Instanciamos la clase
    public static Player sharedInstance;

    // Creamos las variables o estadisticas del personaje
    public float walkSpeed = 5.0f;

    // Traemos variables del Rigidboddy2D
    private Rigidbody2D rigidBody;





    void Start () {

        // Asignamos el valor de la instancia compartida a si mismo
        sharedInstance = this;

        // GetComponent<Rigidbody2D> (Carga los componentes de la clase en una variable)
        rigidBody = GetComponent<Rigidbody2D> ();

     
        
    }

    void Update () {

    float walkUpDown = Input.GetAxis("Vertical") * walkSpeed;
    // Debug.Log (Input.GetAxis ("Vertical")); Mayor que "0" si va hacia arriba (1) y menor que "0" si va hacia abajo (-1)
    float walkLeftRight = Input.GetAxis("Horizontal") * walkSpeed;
    // Debug.Log (Input.GetAxis ("Horizontal")); Mayor que "0" si va hacia la derecha (1) y menor que "0" si va hacia la izquierda (-1)
    walkUpDown *= Time.deltaTime;
    walkLeftRight *= Time.deltaTime;    
    transform.Translate (0, walkUpDown, 0);
    transform.Translate (walkLeftRight, 0, 0); 



    }



    public void WalkHorizontal () {


        
    }


















}
