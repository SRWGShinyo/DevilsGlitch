using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCManager : ObjectManager
{
    public override void OnClick()
    {
        if (selectedObject != null)
        {
            Debug.Log("Already a selected object !");
            return;
        }

        selectedObject = this;
        adm.playPC();
        if (scm.isPCSwitchOn)
        {
            createMCQMessage(0);
        }

        else
        {
            eventUsed = "POKER";
            createSimpleMessage(0);
        }
    }

    public override void OnOptionOneSelected()
    {
        dmg.clearAll();
        scm.isPCSwitchOn = false;
        createSimpleMessage(1);
        eventUsed = "MAIL";
    }

    public override void OnOptionTwoSelected()
    {
        dmg.clearAll();
        createSimpleMessage(0);
        eventUsed = "POKER";
    }

    public override void OnOptionThreeSelected()
    {
        dmg.clearAll();
        selectedObject = null;
        eventUsed = "NOTHING";
        //Leave
    }
}
