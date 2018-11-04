using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiCircle : MonoBehaviour
{
    static float MIN_HEIGHT = -0.1f;

    bool insidePole = false;

    bool isPressed = false;

    bool objectOnTop = false;

    private Rigidbody rb;

    Vector3 positionCurrentPole;

    Vector3 positionCurrentTable;

    float limitY = MIN_HEIGHT;

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
        else if (tagCollision.Equals("Bottom") && !collision.gameObject.transform.IsChildOf(this.transform))
        {
            objectOnTop = true;
        }
        else if (tagCollision.Equals("Top") && !collision.gameObject.transform.IsChildOf(this.transform))
        {
            limitY = transform.position.y;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        string tagCollision = collision.gameObject.tag;
        if (tagCollision.Equals("Bottom") && !collision.gameObject.transform.IsChildOf(this.transform))
        {
            objectOnTop = false;
        }
        else if (tagCollision.Equals("Top") && !collision.gameObject.transform.IsChildOf(this.transform))
        {
            limitY = MIN_HEIGHT;
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

    public void StoppedBeingInPole()
    {
        insidePole = false;
    }

    private void DragDisc()
    {
        if (objectOnTop)
            return;

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
        rb.useGravity = false;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
