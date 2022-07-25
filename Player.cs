using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /*************************************************************************************************************************************/

    // Instanciamos la clase
    public static Player sharedInstance;

    // Creamos las variables o estadisticas del personaje
    public int life;
    public float walkSpeed = 2.0f;
    float view = 1.0f;

    // Traemos variables del Rigidboddy2D
    private Rigidbody2D rigidBody;

    // Traemos variables del Animator  
    private Animator animator;

    public GameObject arrowPrefab;



    void Start () {

        // Asignamos el valor de la instancia compartida a si mismo
        sharedInstance = this;

        // GetComponent<Rigidbody2D> (Carga los componentes de la clase en una variable)
        rigidBody = GetComponent<Rigidbody2D> ();

        // GetComponent<Animator> (Carga los componentes de la clase en una variable)
        animator = GetComponent<Animator> ();

        life = 100;
 
    }

    /*************************************************************************************************************************************/

    void Update () {

    Walk ();
    View ();
    BowAttack (view);


    }

    /*************************************************************************************************************************************/

    public void Walk () {

    if (Input.GetAxis("Fire3") != 0){
        walkSpeed = 4.0f;
    } else {
        walkSpeed = 2.0f;
    }

    // REALIZAMOS LOS MOVIMIENTOS DEL PERSONAJE

    float walkUpDown = Input.GetAxis("Vertical") * walkSpeed;
    // Debug.Log (Input.GetAxis ("Vertical")); Mayor que "0" si va hacia arriba (1) y menor que "0" si va hacia abajo (-1)
    walkUpDown *= Time.deltaTime;
    transform.Translate (0, walkUpDown, 0);

    float walkLeftRight = Input.GetAxis("Horizontal") * walkSpeed;
    // Debug.Log (Input.GetAxis ("Horizontal")); Mayor que "0" si va hacia la derecha (1) y menor que "0" si va hacia la izquierda (-1)
    walkLeftRight *= Time.deltaTime;    
    transform.Translate (walkLeftRight, 0, 0); 

    // REALIZAMOS LAS ANIMACIONES DE LOS MOVIMIENTOS




    float horizontal = Input.GetAxis ("Horizontal");
    float vertical = Input.GetAxis ("Vertical");

    if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0){
        animator.SetFloat ("Horizontal", horizontal);
        animator.SetFloat ("Vertical", vertical);
        animator.SetBool ("Walk", true);
    } else {
        animator.SetBool ("Walk", false);
    }
    
    }

    /*************************************************************************************************************************************/

    public void DamageTaken (int damage){

        life = life - damage;

    }

    public void View (){

        if (Input.GetAxis ("Horizontal") > 0){
            view = 3.0f;
        } else if (Input.GetAxis ("Horizontal") < 0){
            view = 2.0f;
        } else if (Input.GetAxis ("Vertical") > 0){
            view = 4.0f;
        } else if (Input.GetAxis ("Vertical") < 0){
            view = 1.0f;
        }

    }


    void BowAttack (float view){
        
        if (Input.GetButtonDown ("Jump")){
        
            animator.SetFloat ("View", view);
            animator.SetBool ("BowAttack", true);
            StartCoroutine (Arrow(arrowPrefab));

        } else {

            animator.SetBool ("BowAttack", false);

        }
    }

    IEnumerator Arrow (GameObject arrowPrefab){
        yield return new WaitForSeconds(0.85f);
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2 (5.0f, 0.0f);
    }










}
