using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleScript : MonoBehaviour
{

    private float paddleSpeed = 12.5f;
    private float maxX;
    private float moveSpeed = 0;

    public void Awake()
    {
        calculateMaxX();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = Input.GetAxis("Horizontal") * Time.deltaTime * paddleSpeed;
        transform.position += new Vector3(moveSpeed, 0, 0);

        if (transform.position.x <= -maxX || transform.position.x >= maxX)
        {
            float currentX = Mathf.Clamp(transform.position.x, -maxX, maxX);
            transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        rb.velocity = new Vector3(rb.velocity.x + moveSpeed * 20f, rb.velocity.y, rb.velocity.z);
        string objectName = collision.transform.name;
        if (objectName.StartsWith("BuffDouble"))
        {
            Destroy(collision.gameObject);
            transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y, transform.localScale.z);
            calculateMaxX();
        }
        if (objectName.StartsWith("BuffHalf"))
        {
            Destroy(collision.gameObject);
            transform.localScale = new Vector3(transform.localScale.x / 2f, transform.localScale.y, transform.localScale.z);
            calculateMaxX();
        }
        if (objectName.StartsWith("BuffFast"))
        {
            Destroy(collision.gameObject);
            paddleSpeed *= 2f;
        }
        if (objectName.StartsWith("BuffSlow"))
        {
            Destroy(collision.gameObject);
            paddleSpeed /= 2f;
        }
    }

    //Calculate max x value according to the paddle x scale
    public void calculateMaxX()
    {
        maxX = 20f - transform.localScale.x / 2;
    }
}
