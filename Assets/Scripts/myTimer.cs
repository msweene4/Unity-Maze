using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myTimer : MonoBehaviour {

    float timer;
    public Text Display;
    // Use this for initialization
    void Start () {
        GameVariables.begin = false;
        timer = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (GameVariables.begin)
        {
            timer += Time.deltaTime;
            float minutes = Mathf.Floor(timer / 60);
            float seconds = timer % 60;
            Display.text = minutes.ToString("00") + ":" + Mathf.RoundToInt(seconds).ToString("00");
        }
    }
}
