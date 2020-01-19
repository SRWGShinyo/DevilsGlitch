using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAppear : MonoBehaviour
{
    public bool stateOfGlitch;

    void Update()
    {
        if (ObjectManager.eventUsed == "POKER" && GameObject.Find("SceneManager").GetComponent<SceneManagementScript>().hasGlitched == stateOfGlitch)
            GetComponent<SpriteRenderer>().enabled = true;

        else
            GetComponent<SpriteRenderer>().enabled = false;
    }
}
