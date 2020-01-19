using UnityEngine;
using UnityEngine.UI;

public class TextSelection : MonoBehaviour
{
    public Text optionSelect;
    public string optionValue;

    void Update()
    {
        if (isMouseOver())
        {
            optionSelect.color = Color.gray;
        }
        else
        {
            optionSelect.color = Color.black;
        }

        if (isMouseOver() && Input.GetMouseButtonDown(0))
        {
            switch (optionValue)
            {
                case "OP1":
                    if (optionSelect.text == "" || optionSelect.text == null)
                        return;
                    ObjectManager.selectedObject.OnOptionOneSelected();
                    break;
                case "OP2":
                    if (optionSelect.text == "" || optionSelect.text == null)
                        return;
                    ObjectManager.selectedObject.OnOptionTwoSelected();
                    break;
                case "OP3":
                    if (optionSelect.text == "" || optionSelect.text == null)
                        return;
                    ObjectManager.selectedObject.OnOptionThreeSelected();
                    break;
            }
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
