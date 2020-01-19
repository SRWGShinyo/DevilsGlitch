using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : ObjectManager
{
    public override void OnClick()
    {
        if (selectedObject != null)
        {
            Debug.Log("Already a selected object !");
            return;
        }

        selectedObject = this;
        if (scm.canUseKitchen)
        {
            eventUsed = "KITCHEN";
            StartCoroutine("letsCook");
        }

        else
        {
            createSimpleMessage(0);
        }
    }

    private IEnumerator letsCook()
    {
        adm.playCook();
        yield return new WaitForSeconds(5);
        eventUsed = "NOTHING";
        selectedObject = null;
        scm.canUseKitchen = false;
    }
}
