using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject playerObj;
    public GameObject newHighScore;
    public GameObject newHighScoreW;
    int ScoreGameOvr;
    int ScoreWin;
    int highScoreGameOvr;
    int highScoreWin;
    public TMP_Text scoreGText;
    public TMP_Text scoreWText;
    public GameObject pauseMenu;
    public GameObject winGame;
    public GameObject cheatMenu;
    public static bool win;
    bool gameOvr;
    public TMP_InputField codeInputField;
    public string code1;
    public string code2;
    public string code3;
    public TMP_Text codeStatus;
    bool cheatMenuActv;
    bool code2Actv;
    public GameObject loading;
    
    // Start is called before the first frame update
    void Start()
    {
        codeInputField = codeInputField.GetComponent<TMP_InputField>();
        newHighScore.SetActive(false);
        newHighScoreW.SetActive(false);
        highScoreGameOvr = PlayerPrefs.GetInt("highscoredata");
        highScoreWin = PlayerPrefs.GetInt("highscoredata");
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cheatMenuActv){
            codeInputField.onValueChanged.AddListener(delegate {codeInputField.text = codeInputField.text.ToUpper();});
        }
        scoreGText.text = ScoreGameOvr.ToString();
        scoreWText.text = ScoreWin.ToString();

        ScoreGameOvr = scoreManager.score;
        ScoreWin = scoreManager.score;

        if(scoreManager.score > highScoreGameOvr){
            newHighScore.SetActive(true);
        } else{
            newHighScore.SetActive(false);
        }

        if(scoreManager.score > highScoreWin){
            newHighScoreW.SetActive(true);
        } else{
            newHighScoreW.SetActive(false);
        }
        
        if(player.currentHealth <= 0f){
            gameOvr = true;
            PlayerPrefs.SetInt("scoredata", scoreManager.score);
        }

        // Restart Game
        if(win){
            Time.timeScale = 0f;
            winGame.SetActive(true);
            Cursor.visible = true;
            PlayerPrefs.SetInt("scoredata", scoreManager.score);
        } else if(gameOvr){
            Time.timeScale = 0f;
            gameOver.SetActive(true);
            playerObj.SetActive(false);
            Cursor.visible = true;
        } else{
            if(!cheatMenuActv){
                if(Input.GetKeyDown(KeyCode.Escape)){
                    if(Time.timeScale == 1f){
                        pauseMenu.SetActive(true);
                        Time.timeScale = 0f;
                        objectMove.moveSpeed = 0f;
                        Cursor.visible = true;
                    } else{
                        pauseMenu.SetActive(false);
                        Time.timeScale = 1f;
                        Cursor.visible = false;
                    }
                }
            } else {
                if(Input.GetKeyDown(KeyCode.Escape)){
                    cheatMenu.SetActive(false);
                    cheatMenuActv = false;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            if(codeInputField.text == code1){
                player.currentHealth += 100f;
                codeStatus.text = "Cheat Activated";
                codeStatus.color = Color.green;
                codeInputField.text = "";
            } else if(codeInputField.text == code2){
                bullet.cheatDamage = true;
                if(code2Actv){
                    codeStatus.text = "Cheat Already Active";
                    codeStatus.color = Color.red;
                } else{
                    codeStatus.text = "Cheat Activated";
                    codeStatus.color = Color.green;
                    code2Actv = true;
                }
                codeInputField.text = "";
            } else if(codeInputField.text == code3){
                if(scoreIncrease.cheatScoreActv){
                    codeStatus.text = "Cheat Already Active";
                    codeStatus.color = Color.red;
                } else{
                    codeStatus.text = "Cheat Activated";
                    codeStatus.color = Color.green;
                    scoreIncrease.cheatScoreActv = true;
                }
                codeInputField.text = "";
            } else if(codeInputField.text == ""){
                codeStatus.text = "";
            } else{
                codeStatus.text = "Wrong Code";
                codeStatus.color = Color.red;
                codeInputField.text = "";
            }
        }
    }

    public void resumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void restartGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        objectMove.moveSpeed = 0.02f;
        scoreManager.score = 0;
        player.currentHealth = 1100f;
        Cursor.visible = false;
        boss.currentHealth = 100f;
        win = false;
        scoreManager.bossDie = false;
        gameOvr = false;
        bullet.cheatDamage = false;
        loading.SetActive(true);
        scoreIncrease.cheatScoreActv = false;
    }

    public void mainMenu(){
        SceneManager.LoadScene("mainMenu");
        Time.timeScale = 1f;
        objectMove.moveSpeed = 0.02f;
        scoreManager.score = 0;
        Cursor.visible = true;
        player.currentHealth = 100f;
        boss.currentHealth = 100f;
        win = false;
        scoreManager.bossDie = false;
        gameOvr = false;
        bullet.cheatDamage = false;
        loading.SetActive(true);
        scoreIncrease.cheatScoreActv = false;
    }

    public void openCheatMenu(){
        cheatMenu.SetActive(true);
        cheatMenuActv = true;
    }

    public void closeCheatMenu(){
        cheatMenu.SetActive(false);
        codeInputField.text = "";
        codeStatus.text = "";
        cheatMenuActv = false;
    }

    public void checkCode(){
        if(codeInputField.text == code1){
            player.currentHealth += 100f;
            codeStatus.text = "Cheat Activated";
            codeStatus.color = Color.green;
            codeInputField.text = "";
        } else if(codeInputField.text == code2){
            bullet.cheatDamage = true;
            if(code2Actv){
                codeStatus.text = "Cheat Already Active";
                codeStatus.color = Color.red;
                
            } else{
                codeStatus.text = "Cheat Activated";
                codeStatus.color = Color.green;
                code2Actv = true;
            }
            codeInputField.text = "";
        } else if(codeInputField.text == code3){
            if(scoreIncrease.cheatScoreActv){
                    codeStatus.text = "Cheat Already Active";
                    codeStatus.color = Color.red;
                } else{
                    codeStatus.text = "Cheat Activated";
                    codeStatus.color = Color.green;
                    scoreIncrease.cheatScoreActv = true;
                }
                codeInputField.text = "";
        } else if(codeInputField.text == ""){
            codeStatus.text = "";
        } else{
            codeStatus.text = "Wrong Code";
            codeStatus.color = Color.red;
            codeInputField.text = "";
        }
    }
}