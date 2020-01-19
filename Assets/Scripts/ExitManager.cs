using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : ObjectManager
{

    public bool shouldPhoneRingAfter = true;
    public bool shouldPCMailAfter = false;
    public bool shouldSpeakAfterDay = false;

    public override void OnClick()
    {
        if (selectedObject != null)
        {
            return;
        }

        selectedObject = this;
        if (scm.canUseExit)
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
        scm.canUseExit = false;
        createSimpleMessage(1);
        adm.fadeOutMainMusic();
        adm.playDoor();
        StartCoroutine("waitBeforeGoingForth");
    }

    public override void OnOptionTwoSelected()
    {
        scm.hasGlitched = true;
        GameHandler.wishesLeft -= 1;
        scm.canUseExit = false;
        createSimpleMessage(3);
        adm.fadeOutMainMusic();
        adm.playDoor();
        StartCoroutine("waitBeforeGoingForth");
    }

    public override void OnOptionThreeSelected()
    {
        createSimpleMessage(2);
    }

    private IEnumerator waitBeforeGoingBack()
    {
        yield return new WaitForSeconds(4);
        pnH.fadeOut();
        adm.fadeInMusic();
        eventUsed = "NOTHING";
        scm.canUseKitchen = true;
        if (shouldSpeakAfterDay)
            GameObject.Find("MultipleEventManager").GetComponent<GlobalEventMan>().OnClick();
    }

    private IEnumerator waitBeforeGoingForth()
    {
        yield return new WaitForSeconds(1);
        dmg.proceed();
        eventUsed = "EXIT";
        pnH.fadeIn();
        scm.canUseBed = true;
        scm.isPCSwitchOn = scm.isPCSwitchOn ? true : shouldPCMailAfter;
        scm.isTelephoneRinging = scm.isTelephoneRinging ? true : shouldPhoneRingAfter;
        StartCoroutine("waitBeforeGoingBack");
    }
}
