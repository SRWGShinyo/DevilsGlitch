using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    [Serializable]
    public class SingleEvent
    {
        public string[] message;
    }

    [Serializable]
    public class MCQEvent
    {
        public string message;
        public string Option1;
        public string Option2;
        public string Option3;
    }

    public SingleEvent[] allSingleEvents;
    public MCQEvent[] allMCQEvents;

    public static ObjectManager selectedObject;
    public SceneManagementScript scm;
    public AudioManager adm;
    public DialogManager dmg;
    public string onHover;
    protected PanelHandling pnH;

    public static string eventUsed = "NOTHING";

    private void Start()
    {
        scm = GameObject.Find("SceneManager").GetComponent<SceneManagementScript>();
        dmg = GameObject.Find("SceneManager").GetComponent<DialogManager>();
        pnH = GameObject.Find("Fondu").GetComponent<PanelHandling>();
        adm = GameObject.Find("SceneManager").GetComponent<AudioManager>();

        eventUsed = "NOTHING";
    }

    public virtual void OnClick() { }
    public virtual void OnOptionOneSelected() { }
    public virtual void OnOptionTwoSelected() { }
    public virtual void OnOptionThreeSelected() { }

    protected void createSimpleMessage(int index) {
        SingleEvent sng = allSingleEvents[index];
        dmg.displaySingleMessage(sng.message);
    }

    protected void createMCQMessage(int index) {
        MCQEvent mcq = allMCQEvents[index];
        List<string> options = new List<string>();
        options.Add(mcq.Option1);
        options.Add(mcq.Option2);
        options.Add(mcq.Option3);

        dmg.displayMCQ(mcq.message, options.ToArray());
    }
}
