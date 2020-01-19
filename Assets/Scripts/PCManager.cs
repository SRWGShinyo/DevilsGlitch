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
            if (scm.hasTreeStarted && scm.hasGlitched)
                createSimpleMessage(1);
            else if (scm.hasTreeStarted && !scm.hasGlitched)
                createSimpleMessage(0);
            else
                createSimpleMessage(0);
        }
    }

    public override void OnOptionOneSelected()
    {
        dmg.clearAll();
        scm.isPCSwitchOn = false;

        if (scm.hasTreeStarted && scm.hasGlitched)
            createSimpleMessage(2);
        else if (scm.hasTreeStarted && !scm.hasGlitched)
            createSimpleMessage(3);
        else
            createSimpleMessage(1);

        eventUsed = "MAIL";
    }

    public override void OnOptionTwoSelected()
    {
        dmg.clearAll();
        if (scm.hasTreeStarted && scm.hasGlitched)
            createSimpleMessage(1);
        else if (scm.hasTreeStarted && !scm.hasGlitched)
            createSimpleMessage(0);
        else
            createSimpleMessage(0);
        eventUsed = "POKER";
    }

    public override void OnOptionThreeSelected()
    {
        dmg.clearAll();
        selectedObject = null;
        eventUsed = "NOTHING";
    }
}
