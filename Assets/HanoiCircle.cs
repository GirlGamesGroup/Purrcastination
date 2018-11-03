using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiCircle : MonoBehaviour
{

    bool insidePole = false;

    bool collidingWithFloor = false;

    bool isPressed = false;

    private Rigidbody rb;

    Vector3 positionCurrentPole;

    Vector3 positionCurrentTable;

    float limitY = -1.8f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            DragDisc();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        string tagCollision = collision.gameObject.tag;
        if(tagCollision.Equals("Pole"))
        {
            IsInPole(collision.gameObject.transform.position);
        }
        else if(tagCollision.Equals("Out"))
        {
            StoppedBeingInPole();
        }
        else if(tagCollision.Equals("Table"))
        {
            IsTouchingTable(collision.gameObject.transform.position);
        }
        else if (tagCollision.Equals("Base"))
        {
            IsTouchingTable(collision.gameObject.transform.position);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        string tagCollision = collision.gameObject.tag;
        if (tagCollision.Equals("Table"))
        {
            StoppedTouchingTable();
        }
        else if (tagCollision.Equals("Base"))
        {
            StoppedTouchingTable();
        }
    }

    public void IsInPole(Vector3 pole)
    {
        if(!insidePole)
        {
            positionCurrentPole = pole;
            insidePole = true;
        }
    }

    public void IsTouchingTable(Vector3 table)
    {
        positionCurrentTable = table;
        collidingWithFloor = true;
    }

    public void StoppedBeingInPole()
    {
        insidePole = false;
    }

    public void StoppedTouchingTable()
    {
        collidingWithFloor = false;
    }

    private void DragDisc()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePosition.x;
        float y = mousePosition.y;

        if (insidePole)
        {
            x = positionCurrentPole.x;
        }

        if(mousePosition.y < limitY)
        {
            y = limitY;
        }

        rb.position = new Vector3(x, y, 0);
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
    }
}
