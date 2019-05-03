using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class door : MonoBehaviour
{
    public GameObject thedoor;
    public bool isOpen;
    public int doorEvent;
    public Text message;

    void start()
    {
        isOpen = false;
    }

    void OnTriggerEnter(Collider obj)
    {
        if (GameVariables.keyCount > 0 && !isOpen)
        {
            thedoor.GetComponent<Animation>().Play("open");
            GameVariables.keyCount += -1;
            if (doorEvent == 1)
            {
                GameVariables.begin = true;
            }
            if (doorEvent == 2)
            {
                GameVariables.begin = false;
            }
            isOpen = true;
        }
        if (GameVariables.keyCount == 0)
        {
            message.text = "";
        }

    }
}