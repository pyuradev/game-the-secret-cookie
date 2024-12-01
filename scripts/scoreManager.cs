using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public static int score;
    public TMP_Text scoreText;
    public GameObject bossObj;
    public GameObject spawnEnmy;
    public GameObject bossDieObj;
    public AudioSource bossDieSound;
    public static bool bossDie;
    
    void Start(){
        bossDieSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        if(score <= 0){
            score = 0;
        }

        if(score >= 0 && Time.timeScale == 1f){
            objectMove.moveSpeed = 0.06f;
            spawnObject.destroyCount = 4f;
            if(score >= 2500){
                objectMove.moveSpeed = 0.080f;
                spawnObject.destroyCount = 3.5f;
                if(score >= 5000){
                    objectMove.moveSpeed = 0.100f;
                    spawnObject.destroyCount = 3f;
                    if(score >= 7500){
                        objectMove.moveSpeed = 0.120f;
                        spawnObject.destroyCount = 2.5f;
                        if(score >= 9999){
                            objectMove.moveSpeed = 0.140f;
                            spawnObject.destroyCount = 2f;
                        }
                    }
                }
            }
        }

        
        // Secret
        if(scoreManager.score >= 9999 && bossObj != null && spawnEnmy != null){
            bossObj.SetActive(true);
            spawnEnmy.SetActive(true);
            if(boss.currentHealth <= 0f){
                bossDie = true;
                Destroy(bossObj, 0.5f);
                Destroy(spawnEnmy, 0.5f);
                Invoke("bossDieAnim", 0.5f);
                Invoke("winGame", 6f);
            }
        }  

    } // End Update

    void bossDieAnim(){
        bossDieObj.SetActive(true);
        Invoke("bossDieDelay", 3f);
    }

    void winGame(){
        gameManager.win = true;
    }

    void bossDieDelay(){
        Destroy(bossDieObj);
    }
}