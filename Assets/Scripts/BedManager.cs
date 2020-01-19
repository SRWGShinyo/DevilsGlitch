using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BedManager : ObjectManager
{
    public string notToBed;
    public int sceneToLoad;

    public override void OnClick()
    {
        if (selectedObject != null)
        {
            Debug.Log("Already a selected object !");
            return;
        }

        selectedObject = this;
        if (scm.canUseBed)
        {
            createMCQMessage(0);
        }

        else
        {
            createSimpleMessage(0);
        }
    }

    public override void OnOptionOneSelected()
    {
        dmg.clearAll();
        selectedObject = null;
        createSimpleMessage(2);
        eventUsed = "BED";
        adm.fadeOutMainMusic();
        StartCoroutine("waitBeforeGoingForth");
    }

    public override void OnOptionTwoSelected()
    {
        dmg.clearAll();
        selectedObject = null;
        createSimpleMessage(1);
    }

    private IEnumerator waitBeforeGoingForth()
    {
        yield return new WaitForSeconds(3);
        dmg.proceed();
        pnH.fadeIn();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToLoad);
    }
}
