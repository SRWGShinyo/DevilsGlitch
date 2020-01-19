using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilLastWords : ObjectManager
{
    public GameObject jack;

    public static bool hasSolutionBeenChosen = false;

    void Start()
    {
        scm = GameObject.Find("SceneManager").GetComponent<SceneManagementScript>();
        dmg = GameObject.Find("SceneManager").GetComponent<DialogManager>();
        pnH = GameObject.Find("Fondu").GetComponent<PanelHandling>();
        eventUsed = "DEVILAST";
        OnClick();
    }

    public override void OnClick()
    {
        if (selectedObject != null)
            return;

        eventUsed = "DEVILAST";
        selectedObject = this;
        createSimpleMessage(0);
    }

    public void launchSecondDialog()
    {
        jack.SetActive(false);
        hasSolutionBeenChosen = true;
        eventUsed = "DEVILAST";
        selectedObject = this;
        GameHandler.finalScene = "devil";
        createSimpleMessage(1);
    }
}
