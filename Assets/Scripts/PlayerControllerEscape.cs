using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerEscape : MonoBehaviour {

    private Rigidbody2D rBody;
    private bool canJump = true;
    public float jumpHeight = 20;
    private PlayerInput pI;
    private Events events;
    private bool fallen = false;
    


    // Use this for initialization
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        pI = PlayerInput.Instance;
        pI.Jump.AddListener(Jump);
        events = Events.Instance;
        //pI.Crouch.AddListener(Slide);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void Jump()
    {
        if (canJump && !fallen)
        {
            rBody.velocity += new Vector2(0, jumpHeight);
            canJump = false;
        }
    }

    //private void Slide()
    //{
    //    if (canJump)
    //    {
    //        gameObject.transform.up = new Vector3(-1, 0, 0);
    //        canJump = false;
    //        StartCoroutine(slide());
    //    }
    //}

    IEnumerator GetUp(float time)
    {
        yield return new WaitForSeconds(time);
        canJump = true;
        fallen = false;
        gameObject.transform.up = new Vector3(0, 0, 0);
        events.InvokeGottenUp();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (fallen)
            {
                StartCoroutine(GetUp(1f));
            } else
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!fallen)
        {
            collision.gameObject.GetComponent<ObjectMoveScript>().Collision();
            events.InvokeFallen();
            gameObject.transform.up = new Vector3(1, 0, 0);
            fallen = true;
            Rigidbody2D rBody = gameObject.GetComponent<Rigidbody2D>();
            rBody.velocity = new Vector2(rBody.velocity.x, 4f);
        }
    }
}
