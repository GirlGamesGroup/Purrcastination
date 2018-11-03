using UnityEngine;

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