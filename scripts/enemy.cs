using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private float enemyHealth = 100f;
    float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null){
            Transform playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }

        if(enemyHealth <= 0f){
            Destroy(gameObject);
        }

        if(scoreManager.bossDie){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            player.currentHealth -= 5f;
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Bullet"){
            enemyHealth -= 20f;
            Destroy(other.gameObject);
        }
    }
}