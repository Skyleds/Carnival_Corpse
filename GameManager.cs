using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Lo instanciamos a si mismo
    public static GameManager sharedInstance;


    void Start ()
    {
        sharedInstance = this;
    }

    
    void Update ()
    {
        
    }
}
