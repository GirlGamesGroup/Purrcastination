using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawInput : MonoBehaviour
{
    [Header("Cursor")]
    [SerializeField] SpriteRenderer cursorSprite_paintColor;

    [Header("Line:")]
    [SerializeField] GameObject prefab_trail;
    [SerializeField] Color nullColor;

    [Header("Paper:")]
    [SerializeField] Transform paper;


    private Vector3 mousePosition;
    private Color currentColor;

    private Collider2D objSelected;
    private LineDrawer drawing;

    private void Awake()
    {
        currentColor = nullColor;
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            objSelected = Physics2D.OverlapCircle(mousePosition, 0.05f);
            if (objSelected != null)
            {
                if (objSelected.tag == "Paper" && currentColor != nullColor)
                {
                    drawing = Instantiate(prefab_trail, mousePosition, Quaternion.Euler(0.0f, 0.0f, 0.0f),paper).GetComponent<LineDrawer>();
                    drawing.line.startColor = currentColor;
                    drawing.line.endColor = currentColor;
                }
                else if (objSelected.tag == "Color")
                {
                    if(currentColor != nullColor)
                        currentColor = (objSelected.GetComponent<SpriteRenderer>().color + currentColor)/2;
                    else
                        currentColor = objSelected.GetComponent<SpriteRenderer>().color;
                    cursorSprite_paintColor.enabled = true;
                    cursorSprite_paintColor.color = currentColor;
                    objSelected = null;
                }
            }
        }
        else if (objSelected != null && objSelected.tag == "Paper" && currentColor != nullColor)
        {
            if (Input.GetMouseButton(0))
            {
                drawing.line.positionCount++;
                drawing.line.SetPosition(drawing.line.positionCount - 1, mousePosition);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (drawing.simplifyLine)
                {
                    drawing.line.Simplify(drawing.simplifyTolerance);
                }
                drawing.enabled = false;
            }
        }
        

    }

}