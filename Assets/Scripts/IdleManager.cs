using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (ObjectManager.eventUsed != "NOTHING" && ObjectManager.eventUsed != "DEVIL" && ObjectManager.eventUsed != "GLOBAL")
            GetComponent<SpriteRenderer>().enabled = false;
        else
            GetComponent<SpriteRenderer>().enabled = true;
    }
}
