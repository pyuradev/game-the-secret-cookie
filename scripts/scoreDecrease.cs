using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreDecrease : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(scoreManager.bossDie){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            scoreManager.score -= 1;
            player.currentHealth -= 5f;
            Destroy(gameObject);
        }
    }
}