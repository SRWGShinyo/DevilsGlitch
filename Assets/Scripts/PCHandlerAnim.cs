using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCHandlerAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectManager.eventUsed != "MAIL" && ObjectManager.eventUsed != "POKER")
            GetComponent<SpriteRenderer>().enabled = false;
        else
            GetComponent<SpriteRenderer>().enabled = true;
    }
}
