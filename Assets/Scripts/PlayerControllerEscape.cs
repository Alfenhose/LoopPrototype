using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerEscape : MonoBehaviour {

    private Rigidbody2D rBody;
    private bool canJump = true;
    public float jumpHeight = 20;
    private PlayerInput pI;


    // Use this for initialization
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        pI = PlayerInput.Instance;
        pI.Jump.AddListener(Jump);
        pI.Crouch.AddListener(Slide);
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

    private void Slide()
    {
        if (canJump)
        {
            gameObject.transform.up = new Vector3(-1, 0, 0);
            canJump = false;
            StartCoroutine(slide());
        }
    }

    IEnumerator slide()
    {
        yield return new WaitForSeconds(1);
        canJump = true;
        gameObject.transform.up = new Vector3(0, 0, 0);
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
