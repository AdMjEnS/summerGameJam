using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangesToPhysics : MonoBehaviour
{
    public GameController controller;

    private Rigidbody2D rb;

    private float mySpeed;
    private float minimum = -100;
    private float maximum = 100;

    public Vector3 mouseDelta = Vector3.zero;
    private Vector3 lastMousePosition = Vector3.zero;

    private void Start()
    {
        controller = FindAnyObjectByType<GameController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        mouseDelta = Input.mousePosition - lastMousePosition;

        lastMousePosition = Input.mousePosition;
        //Debug.Log(mouseDelta);
    }

    private void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (transform.position.z - Camera.main.transform.position.z)));
        point.z = transform.position.z;
        transform.position = point;
        mySpeed = Mathf.Clamp(rb.angularVelocity, minimum, maximum);
        rb.angularVelocity = mySpeed;
        //Debug.Log(rb.velocity);
    }

    private void OnMouseUpAsButton()
    {
        rb.velocity = new Vector3(mouseDelta.x / 3, mouseDelta.y / 3);
    }

    private void OnMouseDown()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((this.transform.position.x < -3.5 || this.transform.position.x > 3.5) && controller.findObject(this.gameObject))
        {
            controller.removeObject(this.gameObject);
        }
        else if ((this.transform.position.x > -3.5 && this.transform.position.x < 3.5) && controller.findObject(this.gameObject) == false)
        {
            controller.addNewObject(this.gameObject);

        }
    }
}
