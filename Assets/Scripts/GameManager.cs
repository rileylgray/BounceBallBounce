using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public static GameManager instance;
   public int score, highscore, finalScore;
    public Text scoreText, highText;
    Scene currentScene;
    string sceneName;
    public GameObject startUI;
    public Button restart, adButton;
   


    private void Awake()
    {

        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        

        highscore = PlayerPrefs.GetInt("highscore", 0);
        highText.text = highscore.ToString();
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "GameOver")
        {
            finalScore = PlayerPrefs.GetInt("finalscore", 0);
            scoreText.text = finalScore.ToString();

        }
      

    }
 
    // Update is called once per frame
    void Update()
    {
     

    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

  

    public void Death()
    {
       // GUIUtility.ExitGUI();
        SceneManager.LoadScene("GameOver");

        
    }


    public void ScoreUpdater()
    {
        score++;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("finalscore", score);
        PlayerPrefs.Save();
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
            highscore = score;
        }
    }

    public void GameStart()
    {
        startUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }



    

}
