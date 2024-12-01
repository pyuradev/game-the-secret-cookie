using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class boss : MonoBehaviour
{
    public Image healthBar;
    public static float currentHealth = 100f;
    public Animator bossAnim;
    public GameObject bossObj;
    public GameObject warningBoss;
    float minTime = 2f;
    float maxTime = 3f;
    float time;

    // Update is called once per frame
    void Start()
    {
        time = Random.Range(minTime, maxTime);
        bossAnim = GetComponent<Animator>();
        StartCoroutine(bossAnimation());
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            player.currentHealth -= 10f;
        }
    }

    void Update(){
        healthBar.fillAmount = currentHealth / 100f;
        
        if(scoreManager.bossDie == true){
            StopAllCoroutines();
            bossAnim.SetTrigger("BossIdle");
        }

    } // End Update
    
    IEnumerator bossAnimation(){
        yield return new WaitForSeconds(time);
        bossAnim.SetTrigger("BossLeft");
        yield return new WaitForSeconds(time);
        bossAnim.SetTrigger("BossIdle");
        yield return new WaitForSeconds(time);
        bossAnim.SetTrigger("BossRight");
        yield return new WaitForSeconds(time);
        bossAnim.SetTrigger("BossIdle");
        yield return new WaitForSeconds(time);
        warningBoss.SetActive(true);
        yield return new WaitForSeconds(time);
        bossAnim.SetTrigger("BossFront");
        warningBoss.SetActive(false);
        yield return new WaitForSeconds(time);
        bossAnim.SetTrigger("BossIdle");
        yield return new WaitForSeconds(time);
        time = Random.Range(minTime, maxTime);
        StartCoroutine(bossAnimation());
    }
}