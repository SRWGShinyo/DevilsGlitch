using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastSceneWork : MonoBehaviour
{
    public Text toDisplay;

    public string giveINCrea;
    public string glitchCrea;
    public string giveINPolice;
    public string glitchPolice;
    public string devil;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DisplayText");
    }


    private IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(3);
        switch (GameHandler.finalScene)
        {
            case "creaglitch":
                toDisplay.text = glitchCrea;
                break;
            case "creagivein":
                toDisplay.text = giveINCrea;
                break;
            case "poliglitch":
                toDisplay.text = glitchPolice;
                break;
            case "poligivein":
                toDisplay.text = giveINPolice;
                break;
            case "devil":
                toDisplay.text = devil;
                break;
        }
    }
}
