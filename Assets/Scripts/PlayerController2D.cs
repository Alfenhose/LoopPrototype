using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    private Rigidbody2D rBody;
    private bool canJump = true;
    public float jumpHeight = 20;
    public float moveSpeed = 10;
    public float acceleration = 75;
    public float jumpSpeedModifier = 0.5f;
    private PlayerInput pI;
    

    // Use this for initialization
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        pI = PlayerInput.Instance;
        pI.Jump.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
        float jsm;
        if (canJump)
        {
            jsm = 1;
        } else
        {
            jsm = jumpSpeedModifier;
        }
        if (pI.Horizontal > 0)
        {
            rBody.velocity = new Vector2(Mathf.MoveTowards(rBody.velocity.x, moveSpeed, acceleration * Time.deltaTime * jsm), rBody.velocity.y);
        }
        else if (pI.Horizontal < 0)
        {
            rBody.velocity = new Vector2(Mathf.MoveTowards(rBody.velocity.x, -moveSpeed, acceleration * Time.deltaTime * jsm), rBody.velocity.y);
        }
        else
        {
            rBody.velocity = new Vector2(Mathf.MoveTowards(rBody.velocity.x, 0, acceleration * Time.deltaTime * jsm), rBody.velocity.y);
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            rBody.velocity += new Vector2(0, jumpHeight);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }

    }
}
