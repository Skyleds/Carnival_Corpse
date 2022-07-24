using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D player) {
        if (player.tag == "Player") {
            if (player.GetType () == typeof(BoxCollider2D)){
                Player.sharedInstance.DamageTaken (5); 
            } else if (player.GetType () == typeof(CircleCollider2D)){
                Player.sharedInstance.DamageTaken (10); 
            }
            
        }
    }

}
