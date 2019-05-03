using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardCount : MonoBehaviour {

    public Text count;
    void Start()
    {
        GameVariables.keyCount = 0;
        displayCount();
    }
    void Update()
    {
        displayCount();
    }
    public void displayCount()
    {
        count.text = "Key Card Count: " + GameVariables.keyCount;
    }
}
