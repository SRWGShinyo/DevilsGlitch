using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : ObjectManager
{

    public GameObject phoneAnim;

    public override void OnClick()
    {
        if (selectedObject != null)
        {
            return;
        }

        selectedObject = this;
        adm.playPhone();
        if (scm.isTelephoneRinging)
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
        eventUsed = "PHONE";
        scm.isTelephoneRinging = false;
        phoneAnim.GetComponent<SpriteRenderer>().enabled = true;
        createSimpleMessage(1);
    }

    public override void OnOptionTwoSelected()
    {
        dmg.clearAll();
        createSimpleMessage(2);
    }
}
