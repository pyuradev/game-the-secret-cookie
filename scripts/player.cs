using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Image limitHlth;
    public static float currentHealth = 100f;
    public GameObject spawnBullet;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 10f;

        // limit position
        mousePos.x = Mathf.Clamp(mousePos.x, -8.2f, 8.2f);
        mousePos.y = Mathf.Clamp(mousePos.y, -4.3f, 4.3f);

        if(Time.timeScale == 1f){
            transform.position = mousePos;
        } else{
            transform.position = transform.position;
        }

        var x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(x, y, 0f);

        minusHungryBar();

        // Secret
        if(scoreManager.score >= 9999 && spawnBullet != null){
            spawnBullet.SetActive(true);
        }
    }

    void FixedUpdate(){
        if(currentHealth > 100f){
            currentHealth = 100f;
        }
    }

    public void minusHungryBar(){
        if(!scoreManager.bossDie){
            if(scoreManager.score < 1000){
                currentHealth -= 3f * Time.deltaTime;
            } else if(scoreManager.score >= 1000){
                currentHealth -= 3.5f * Time.deltaTime;
            } else if(scoreManager.score >= 5000){
                currentHealth -= 4f * Time.deltaTime;
            }

            limitHlth.fillAmount = currentHealth / 100f;
        }
    }
}