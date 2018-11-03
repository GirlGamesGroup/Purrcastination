using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawInput : MonoBehaviour
{

    [SerializeField] Transform cursor;
    [SerializeField] SpriteRenderer sprite_paintColor;
    [SerializeField] GameObject prefab_trail;
    private Vector3 mousePosition;
    private LineDrawer drawing;
    private Collider2D objSelected;
    private Color currentColor;
    private bool hasColorBeenChoose = false;
    

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        cursor.position = mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                objSelected = Physics2D.OverlapCircle(mousePosition, 0.05f);
                if (objSelected != null)
                {
                    if (objSelected.tag == "Paper" && hasColorBeenChoose)
                    {
                        drawing = Instantiate(prefab_trail, mousePosition, Quaternion.Euler(0.0f, 0.0f, 0.0f)).GetComponent<LineDrawer>();
                        drawing.line.startColor = currentColor;
                        drawing.line.endColor = currentColor;
                    }
                    else if (objSelected.tag == "Color")
                    {
                        hasColorBeenChoose = true;
                        currentColor = objSelected.GetComponent<SpriteRenderer>().color;
                        sprite_paintColor.color = currentColor;
                        objSelected = null;
                    }
                }
            }
            else if (Input.GetMouseButton(0) && objSelected != null && hasColorBeenChoose)
            {
                drawing.line.positionCount++;
                drawing.line.SetPosition(drawing.line.positionCount - 1, mousePosition);
            }
            else if (Input.GetMouseButtonUp(0) && objSelected != null && hasColorBeenChoose)
            {
                if (drawing.simplifyLine)
                {
                    drawing.line.Simplify(drawing.simplifyTolerance);
                }
                drawing.enabled = false;
            }
        

    }

}