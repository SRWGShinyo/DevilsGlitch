using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDisplayer : MonoBehaviour
{
    public int requiredwished;

    void Update()
    {
        if (GameHandler.wishesLeft != requiredwished)
            GetComponent<SpriteRenderer>().enabled = false;
        else
            GetComponent<SpriteRenderer>().enabled = true;
    }
}
