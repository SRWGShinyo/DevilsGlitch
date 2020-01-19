using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreancierManager : ObjectManager
{
    public GameObject crea1;
    public GameObject crea2;

    public static bool hasSolutionBeenChosen = false;

    void Start()
    {
        scm = GameObject.Find("SceneManager").GetComponent<SceneManagementScript>();
        dmg = GameObject.Find("SceneManager").GetComponent<DialogManager>();
        pnH = GameObject.Find("Fondu").GetComponent<PanelHandling>();
        eventUsed = "CREANCIER";
        OnClick();
    }

    public override void OnClick()
    {
        if (selectedObject != null)
            return;

        eventUsed = "CREANCIER";
        selectedObject = this;
        createSimpleMessage(0);
    }

    public void goToMCQ()
    {
        eventUsed = "CREANCIER";
        selectedObject = this;
        createMCQMessage(0);
    }

    public override void OnOptionOneSelected()
    {
        crea1.GetComponent<SpriteRenderer>().enabled = false;
        crea2.GetComponent<SpriteRenderer>().enabled = false;
        GameHandler.wishesLeft -= 1;
        createSimpleMessage(1);
        hasSolutionBeenChosen = true;
        GameHandler.finalScene = "creaglitch";
    }

    public override void OnOptionTwoSelected()
    {
        createSimpleMessage(2);
        hasSolutionBeenChosen = true;
        GameHandler.finalScene = "creagivein";
    }
}
