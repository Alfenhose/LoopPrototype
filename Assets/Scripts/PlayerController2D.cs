using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour {

    private Rigidbody2D rBody;
    private bool canJump = true;
    public float jumpHeight;

	// Use this for initialization
	void Start () {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        PlayerInput.Instance.Jump.AddListener(Jump);
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void Jump()
    {
        if (canJump)
        {
            rBody.velocity += new Vector2(0, jumpHeight);
            canJump = false;
        }
    }

    private void moveHorizontally()
    {

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
