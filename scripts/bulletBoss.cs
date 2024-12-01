using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.4f);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            player.currentHealth -= 5f;
            Destroy(gameObject);
        }
    }
}