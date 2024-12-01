using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBullet : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    float speedBullet = 15f;
    float secondSpawn = 0.1f;
    public AudioSource hitSounds;

    void Start(){
        hitSounds = GetComponent<AudioSource>();
        StartCoroutine(spawnBlt());
    }

    IEnumerator spawnBlt(){
        yield return new WaitForSeconds(secondSpawn);
        hitSounds.PlayOneShot(hitSounds.clip);
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * speedBullet;
        StartCoroutine(spawnBlt());
    }

    void Update(){
        if(boss.currentHealth <= 0f){
            Destroy(gameObject);
        }
    }
}