using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppearOnHover : MonoBehaviour
{
    public static AppearOnHover appH;

    SpriteRenderer sprite;
    public Text toappear;
    public string nameObject;

    DialogManager dmg;
    ObjectManager obj;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    private void Start()
    {
        toappear.enabled = false;
        dmg = GameObject.Find("SceneManager").GetComponent<DialogManager>();
        obj = GetComponent<ObjectManager>();
    }

    void Update()
    {
        if (PanelHandling.isHere)
            return;

        if (appH && appH == this && Input.GetMouseButton(0))
        {
            if (obj)
                obj.OnClick();
        }

        if (isMouseOver())
        {
            if (ObjectManager.selectedObject)
                return;

            sprite.enabled = true;
            toappear.enabled = true;
            appH = this;

            if (obj)
                dmg.fullDisp.text = obj.onHover;

        }

        else if (appH && appH == this)
        {
            sprite.enabled = false;
            toappear.enabled = false;
            appH = null;
            if (!ObjectManager.selectedObject)
                dmg.clearAll();
        }

    }

    private bool isMouseOver()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject.name == gameObject.name)
            return true;
        return false;
    } 
}
