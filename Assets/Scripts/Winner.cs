using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winner : MonoBehaviour {

    public Text finishT;
    public InputField inputField;
    public GameObject IF;
    public GameObject submit;
    public GameObject pause;

    void Start()
    {
        inputField.DeactivateInputField();
        inputField.characterLimit = 3;
        IF.SetActive(false);
        submit.SetActive(false);
        pause.SetActive(false);
        Time.timeScale = 1;//Allows playing after pressing restart or main menu from pause screen.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause.active)
            {
                PauseGame();
            }
            else
            {
                ContinueGame();
            }
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
        //enable the scripts again
    }

    void OnTriggerEnter(Collider obj)
    {
        Time.timeScale = 0;
        inputField.ActivateInputField();
        IF.SetActive(true);
        submit.SetActive(true);
        
    }

    bool compareTimes(int minA, int secA, int minB, int secB)
    {
        if (minA < minB)
        {
            return true;
        }
        else if (minA == minB)
        {
            if (secA < secB)
            {
                return true;
            }
        }
        return false;
    }

    public void submitName()
    {
        string[] time = finishT.text.Split(':');
        int finM = int.Parse(time[0]);
        int finS = int.Parse(time[1]);

        //If there are no scores.
        if (!(PlayerPrefs.HasKey("name0")))
        {
            PlayerPrefs.SetString("name0", inputField.text);
            PlayerPrefs.SetString("score0", finishT.text);
        }
        else if (!(PlayerPrefs.HasKey("name1")))//If there is no second score.
        {
            string[] bTime = PlayerPrefs.GetString("score0").Split(':');
            //new time better than top time.
            if(compareTimes(finM,finS,int.Parse(bTime[0]), int.Parse(bTime[1])))
            {
                PlayerPrefs.SetString("name1", PlayerPrefs.GetString("name0"));
                PlayerPrefs.SetString("score1", PlayerPrefs.GetString("score0"));
                PlayerPrefs.SetString("name0", inputField.text);
                PlayerPrefs.SetString("score0", finishT.text);
            }
            else
            {
                PlayerPrefs.SetString("name1", inputField.text);
                PlayerPrefs.SetString("score1", finishT.text);
            }
        }
        else if (!(PlayerPrefs.HasKey("name2")))//If there is no third score.
        {
            string[] bTime = PlayerPrefs.GetString("score0").Split(':');
            string[] cTime = PlayerPrefs.GetString("score1").Split(':');
            //new time better than top time.
            if (compareTimes(finM, finS, int.Parse(bTime[0]), int.Parse(bTime[1])))
            {
                PlayerPrefs.SetString("name2", PlayerPrefs.GetString("name1"));
                PlayerPrefs.SetString("score2", PlayerPrefs.GetString("score1"));
                PlayerPrefs.SetString("name1", PlayerPrefs.GetString("name0"));
                PlayerPrefs.SetString("score1", PlayerPrefs.GetString("score0"));
                PlayerPrefs.SetString("name0", inputField.text);
                PlayerPrefs.SetString("score0", finishT.text);
            }
            else if(compareTimes(finM, finS, int.Parse(cTime[0]), int.Parse(cTime[1])))//new time better than second time.
            {
                PlayerPrefs.SetString("name2", PlayerPrefs.GetString("name1"));
                PlayerPrefs.SetString("score2", PlayerPrefs.GetString("score1"));
                PlayerPrefs.SetString("name1", inputField.text);
                PlayerPrefs.SetString("score1", finishT.text);
            }
            else
            {
                PlayerPrefs.SetString("name2", inputField.text);
                PlayerPrefs.SetString("score2", finishT.text);
            }
        }
        else//full leaderboard
        {
            string[] bTime = PlayerPrefs.GetString("score0").Split(':');
            string[] cTime = PlayerPrefs.GetString("score1").Split(':');
            string[] dTime = PlayerPrefs.GetString("score2").Split(':');
            //new time better than top time.
            if (compareTimes(finM, finS, int.Parse(bTime[0]), int.Parse(bTime[1])))
            {
                PlayerPrefs.SetString("name2", PlayerPrefs.GetString("name1"));
                PlayerPrefs.SetString("score2", PlayerPrefs.GetString("score1"));
                PlayerPrefs.SetString("name1", PlayerPrefs.GetString("name0"));
                PlayerPrefs.SetString("score1", PlayerPrefs.GetString("score0"));
                PlayerPrefs.SetString("name0", inputField.text);
                PlayerPrefs.SetString("score0", finishT.text);
            }
            else if (compareTimes(finM, finS, int.Parse(cTime[0]), int.Parse(cTime[1])))//new time better than second time.
            {
                PlayerPrefs.SetString("name2", PlayerPrefs.GetString("name1"));
                PlayerPrefs.SetString("score2", PlayerPrefs.GetString("score1"));
                PlayerPrefs.SetString("name1", inputField.text);
                PlayerPrefs.SetString("score1", finishT.text);
            }
            else if (compareTimes(finM, finS, int.Parse(dTime[0]), int.Parse(dTime[1])))//new time better than third time.
            {
                PlayerPrefs.SetString("name2", inputField.text);
                PlayerPrefs.SetString("score2", finishT.text);
            }
        }

        SceneManager.LoadScene("Scores");
    }
}
