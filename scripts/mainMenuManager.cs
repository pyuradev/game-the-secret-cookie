using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainMenuManager : MonoBehaviour
{
    int highScoreM;
    int scoreM;
    public TMP_Text highScoreMText;
    public GameObject areUSureMenu;
    public GameObject loading;
    public GameObject creditsMenu;
    public GameObject htpMenu;

    // Start is called before the first frame update
    void Start()
    {
        scoreM = PlayerPrefs.GetInt("scoredata");
        highScoreM = PlayerPrefs.GetInt("highscoredata");
    }

    // Update is called once per frame
    void Update()
    {
        highScoreMText.text = highScoreM.ToString();

        if(scoreM > highScoreM){
            highScoreM = scoreM;
            PlayerPrefs.SetInt("highscoredata", highScoreM);
        }
    }

    public void startGame(){
        loading.SetActive(true);
        SceneManager.LoadScene("inGame");
    }

    public void openHowToPlay(){
        htpMenu.SetActive(true);
    }

    public void closeHowToPlay(){
        htpMenu.SetActive(false);
    }
    
    public void openCredits(){
        creditsMenu.SetActive(true);
    }

    public void closeCredits(){
        creditsMenu.SetActive(false);
    }

    public void areYouSure(){
        areUSureMenu.SetActive(true);
    }

    public void yesExit(){
        Application.Quit();
        Debug.Log("You Has Exit");
    }

    public void cancelExit(){
        areUSureMenu.SetActive(false);
    }
}