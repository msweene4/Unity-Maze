using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upLeader : MonoBehaviour {
    public Text name0;
    public Text score0;
    public Text name1;
    public Text score1;
    public Text name2;
    public Text score2;

    // Use this for initialization
    void Start() {
        if (PlayerPrefs.HasKey("name0")) { 
            name0.text = PlayerPrefs.GetString("name0");
            score0.text = PlayerPrefs.GetString("score0");
        }
        if (PlayerPrefs.HasKey("name1"))
        {
            name1.text = PlayerPrefs.GetString("name1");
            score1.text = PlayerPrefs.GetString("score1");
        }
        if (PlayerPrefs.HasKey("name2"))
        {
            name2.text = PlayerPrefs.GetString("name2");
            score2.text = PlayerPrefs.GetString("score2");
        }
    }
}
