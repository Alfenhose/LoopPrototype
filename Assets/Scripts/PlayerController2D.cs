using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour {

    private Rigidbody2D rBody;
    private bool canJump = true;
    public float jumpHeight = 10;
    public float moveSpeed = 10;
    private bool moving = false;

	// Use this for initialization
	void Start () {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        PlayerInput.Instance.Jump.AddListener(Jump);
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerInput.Instance.Horizontal > 0)
        {
            MoveRight();
        } else if (PlayerInput.Instance.Horizontal < 0)
        {
            MoveLeft();
        } else if (canJump)
        {
            rBody.velocity = new Vector2(0, rBody.velocity.y);
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

    private void MoveRight()
    {
        if (canJump)
        {
            rBody.velocity = new Vector2(moveSpeed, rBody.velocity.y);
        }
        else
        {
            if(rBody.velocity.x < moveSpeed)
            {
                rBody.velocity += new Vector2(moveSpeed * 1.5f * Time.deltaTime, 0);
            }
        }
        
        moving = true;
    }

    private void MoveLeft()
    {
        if (canJump)
        {
            rBody.velocity = new Vector2(-moveSpeed, rBody.velocity.y);
        }
        else
        {
            if (rBody.velocity.x > -moveSpeed)
            {
                rBody.velocity += new Vector2(-moveSpeed * 1.5f * Time.deltaTime, 0);
            }
        }
        moving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
}
