using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float damage;
    public static bool cheatDamage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.6f);
    }

    void FixedUpdate()
    {
        if(cheatDamage){
            damage = 15f;
        } else{
            damage = 0.5f;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Boss"){
            boss.currentHealth -= damage;
            Destroy(gameObject);
        }
    }
}