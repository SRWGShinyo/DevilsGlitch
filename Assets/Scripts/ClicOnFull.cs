using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicOnFull : MonoBehaviour
{
    DialogManager dmg;
    float ttW = 1f;
    // Start is called before the first frame update
    void Start()
    {
        dmg = GameObject.Find("SceneManager").GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isMouseOver() && ttW <= 0f)
            dmg.proceed();

        if (ttW > 0f && GetComponent<BoxCollider2D>().enabled == true)
            ttW -= 0.1f;

        if (GetComponent<BoxCollider2D>().enabled == false)
            ttW = 1f;
    }

    private bool isMouseOver()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.name == gameObject.name)
            return true;
        return false;
    }
}
