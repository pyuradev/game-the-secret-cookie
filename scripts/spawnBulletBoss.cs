using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBulletBoss : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    float speedBullet = 15f;
    float secondSpawn = 0.1f;

    void Start(){
        StartCoroutine(spawnBltBoss());
    }

    IEnumerator spawnBltBoss(){
        yield return new WaitForSeconds(secondSpawn);
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = -bulletSpawnPoint.up * speedBullet;
        StartCoroutine(spawnBltBoss());
    }

    void Update(){
        if(boss.currentHealth <= 0f){
            Destroy(gameObject);
        }        
    }
}