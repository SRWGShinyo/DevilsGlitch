using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventMan : ObjectManager
{
    public bool shouldPlayOnTheGo = true;
    public int indexInCourse = 0;

    // Start is called before the first frame update
    void Start()
    {
        scm = GameObject.Find("SceneManager").GetComponent<SceneManagementScript>();
        dmg = GameObject.Find("SceneManager").GetComponent<DialogManager>();
        pnH = GameObject.Find("Fondu").GetComponent<PanelHandling>();
        if (shouldPlayOnTheGo)
            OnClick();
    }

    public override void OnClick()
    {
        if (selectedObject != null || indexInCourse >= allSingleEvents.Length)
            return;

        eventUsed = "GLOBAL";
        selectedObject = this;
        createSimpleMessage(indexInCourse);
        indexInCourse += 1;
    }
}
