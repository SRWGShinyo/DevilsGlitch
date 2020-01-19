using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static string displayType;
    public static bool shouldRemoveOne = false;

    public Text continueText;
    public Text fullDisp;
    public Text Oneline;
    public Text Option1;
    public Text Option2;
    public Text Option3;

    public BoxCollider2D fullDispCollider;
    public BoxCollider2D opt1Collider;
    public BoxCollider2D opt2Collider;
    public BoxCollider2D opt3Collider;

    string[] allSentences;
    int actualIndex = 0;

    public void clearAll()
    {
        fullDisp.text = "";
        Oneline.text = "";
        Option1.text = "";
        Option2.text = "";
        Option3.text = "";
        continueText.text = "";

        displayType = "NEUTRAL";
        allSentences = null;
        actualIndex = 0;
    }

    public void displaySingleMessage(string[] sentences)
    {
        fullDispCollider.enabled = true;
        opt1Collider.enabled = false;
        opt2Collider.enabled = false;
        opt3Collider.enabled = false;

        if (allSentences == null || allSentences.Length != 0 || displayType == "MULTIPLE")
        {
            if (displayType != "SINGLE")
                clearAll();
            allSentences = sentences;
            continueText.text = "Click to continue...";
            displayType = "SINGLE";
        }

        if (actualIndex >= allSentences.Length)
        {
            clearAll();
            ObjectManager.selectedObject = null;
            string evet = ObjectManager.eventUsed;
            Debug.Log(evet);
            if (evet == "BED")
                return;

            ObjectManager.eventUsed = "NOTHING";
            if (evet == "CREANCIER")
            {
                if (CreancierManager.hasSolutionBeenChosen)
                {
                    GameObject.Find("GameHandler").GetComponent<GameHandler>().endTheGame();
                    return;
                }
                GameObject.Find("MultipleEventManager").GetComponent<CreancierManager>().goToMCQ();
                return;
            }

            if (evet == "POLICE")
            {
                if (PoliceManager.hasSolutionBeenChosen)
                {
                    GameObject.Find("GameHandler").GetComponent<GameHandler>().endTheGame();
                    return;
                }

                GameObject.Find("MultipleEventManager").GetComponent<PoliceManager>().goToMCQ();
                return;
            }

            if (evet == "DEVILAST")
            {
                if (DevilLastWords.hasSolutionBeenChosen)
                {
                    GameObject.Find("GameHandler").GetComponent<GameHandler>().endTheGame();
                    return;
                }

                GameObject.Find("MultipleEventManager").GetComponent<DevilLastWords>().launchSecondDialog();
                return;
            }

            if (shouldRemoveOne)
            {
                GameHandler.wishesLeft -= 1;
                shouldRemoveOne = false;
            }
            if (evet == "DEVIL") {
                GameObject.Find("SceneManager").GetComponent<AudioManager>().fadeToMain();
                if (GameObject.Find("MultipleEventManager").GetComponent<DevilEventManager>().hasTextAfterDevil)
                {
                    Debug.Log("Text after devil !");
                    shouldRemoveOne = true;
                    GameObject.Find("MultipleEventManager").GetComponent<GlobalEventMan>().OnClick();
                }
            }
            return;
        }

        allSentences = sentences;
        fullDisp.text = allSentences[actualIndex];
        actualIndex++;
    }

    public void displayMCQ(string message, string[] options)
    {
        fullDispCollider.enabled = false;
        opt1Collider.enabled = true;
        opt2Collider.enabled = true;
        opt3Collider.enabled = true;

        if (allSentences == null || allSentences.Length == 0 || displayType == "SINGLE")
        {
            if (displayType != "MULTIPLE")
                clearAll();
            allSentences = options;
            displayType = "MULTIPLE";
        }

        allSentences = options;
        Oneline.text = message;
        Option1.text = options.Length >= 1 ? options[0] : "";
        Option2.text = options.Length >= 2 ? options[1] : "";
        Option3.text = options.Length >= 3 ? options[2] : "";
    }

    public void proceed()
    {
        if (displayType == "MULTIPLE")
            return;

        if (allSentences == null)
        {
            Debug.Log("proceed: Allsentences is null");
            return;
        }
        displaySingleMessage(allSentences);
    }
}
