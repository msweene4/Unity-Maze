using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class pickupKey : MonoBehaviour {

    public GameObject theKey;
    public Text message;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)){
            GameVariables.keyCount += 1;
            Destroy(theKey);
            message.text = "Got a key card!! Use it to open a door.";
        }
    }
}
