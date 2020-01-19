using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceManager : ObjectManager
{
    public GameObject police1;
    public GameObject police2;

    public static bool hasSolutionBeenChosen = false;

    void Start()
    {
        scm = GameObject.Find("SceneManager").GetComponent<SceneManagementScript>();
        dmg = GameObject.Find("SceneManager").GetComponent<DialogManager>();
        pnH = GameObject.Find("Fondu").GetComponent<PanelHandling>();
        eventUsed = "POLICE";
        OnClick();
    }

    public override void OnClick()
    {
        if (selectedObject != null)
            return;

        eventUsed = "POLICE";
        selectedObject = this;
        createSimpleMessage(0);
    }

    public void goToMCQ()
    {
        eventUsed = "POLICE";
        selectedObject = this;
        createMCQMessage(0);
    }

    public override void OnOptionOneSelected()
    {
        police1.GetComponent<SpriteRenderer>().enabled = false;
        police2.GetComponent<SpriteRenderer>().enabled = false;
        createSimpleMessage(1);
        hasSolutionBeenChosen = true;
        GameHandler.wishesLeft -= 1;
        GameHandler.finalScene = "poliglitch";
    }

    public override void OnOptionTwoSelected()
    {
        createSimpleMessage(2);
        hasSolutionBeenChosen = true;
        GameHandler.finalScene = "poligivein";
    }
}
