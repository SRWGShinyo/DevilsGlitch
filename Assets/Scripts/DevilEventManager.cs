using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilEventManager : ObjectManager
{
    public bool hasTextAfterDevil = false;
    public int indexInCourse = 0;

    // Start is called before the first frame update
    void Start()
    {
        scm = GameObject.Find("SceneManager").GetComponent<SceneManagementScript>();
        dmg = GameObject.Find("SceneManager").GetComponent<DialogManager>();
        pnH = GameObject.Find("Fondu").GetComponent<PanelHandling>();


        OnClick();
    }

    public override void OnClick()
    {
        if (selectedObject != null || indexInCourse >= allSingleEvents.Length)
            return;

        eventUsed = "DEVIL";
        selectedObject = this;
        scm.hasGlitched = true;
        createSimpleMessage(indexInCourse);
    }
}
