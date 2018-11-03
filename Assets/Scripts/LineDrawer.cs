using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// © 2018 TheFlyingKeyboard and released under MIT License 
// theflyingkeyboard.net 
public class LineDrawer : MonoBehaviour
{
    public LineRenderer line;
    public bool simplifyLine = false;
    public float simplifyTolerance = 0.02f;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount++;
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButton(0)) 
    //    {
    //        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        line.positionCount++;
    //        line.SetPosition(line.positionCount - 1, mousePosition);
         
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        if (simplifyLine)
    //        {
    //            line.Simplify(simplifyTolerance);
    //        }
    //        enabled = false; 
    //    }
    //}
}