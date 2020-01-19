using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnappearhenNoevent : MonoBehaviour
{
    public string whenToAppear;

    void Update()
    {
        if (ObjectManager.eventUsed != whenToAppear)
            GetComponent<SpriteRenderer>().enabled = false;
        else
            GetComponent<SpriteRenderer>().enabled = true;
    }
}
