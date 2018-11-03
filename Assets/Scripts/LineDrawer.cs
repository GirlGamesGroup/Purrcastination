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
    }
}