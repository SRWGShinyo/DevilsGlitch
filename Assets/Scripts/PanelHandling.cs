using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelHandling : MonoBehaviour
{
    public static bool isHere = true;
    public Text text;
    float targetAlpha;

    private void Start()
    {
        StartCoroutine("TextDisappear");
        fadeOut();
    }

    private void Update()
    {
        Color imageCol = GetComponent<Image>().color;

        if (imageCol.a >= targetAlpha && targetAlpha == 0)
            isHere = false;

        if (imageCol.a >= targetAlpha && targetAlpha == 1)
            isHere = true;

        if (imageCol.a < targetAlpha)
        {
            imageCol.a += 0.01f;
        }

        if (imageCol.a > targetAlpha)
        {
            imageCol.a -= 0.01f;
        }

        GetComponent<Image>().color = imageCol;
    }

    public void fadeIn() {
        targetAlpha = 1f;
    }

    public void fadeOut() {
        targetAlpha = 0f;
    }

    private IEnumerator TextDisappear()
    {
        yield return new WaitForSeconds(1.2f);
        text.text = "";
    }
}
