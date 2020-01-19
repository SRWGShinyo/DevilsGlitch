using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailAppear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ObjectManager.eventUsed == "MAIL")
            GetComponent<SpriteRenderer>().enabled = true;

        else
            GetComponent<SpriteRenderer>().enabled = false;
    }
}
