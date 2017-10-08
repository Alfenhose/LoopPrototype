using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceChase : MonoBehaviour
{

    private Rigidbody2D rBody;
    private bool canJump = true;
    public float jumpHeight = 20;
    private Events events;
    private bool fallen = false;
    public float moveSpeed = 4;
    public float fallingModifier = 5;


    // Use this for initialization
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        events = Events.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (fallen)
        {
            rBody.velocity = new Vector2(events.scrollSpeed* 0.8f, rBody.velocity.y);
            //rBody.velocity = new Vector2(Mathf.MoveTowards(rBody.velocity.x, events.scrollSpeed, fallingModifier * Time.deltaTime), rBody.velocity.y);
        }
        else
        {
            rBody.velocity = new Vector2(events.scrollSpeed/2 + moveSpeed, rBody.velocity.y);
            //rBody.velocity = new Vector2(Mathf.MoveTowards(rBody.velocity.x, events.scrollSpeed + moveSpeed, fallingModifier * Time.deltaTime), rBody.velocity.y);
        }

    }

    private void Jump()
    {
        if (canJump && !fallen)
        {
            rBody.velocity += new Vector2(0, jumpHeight);
            canJump = false;
        }
    }

    IEnumerator GetUp(float time)
    {
        yield return new WaitForSeconds(time);
        canJump = true;
        fallen = false;
        gameObject.transform.up = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (fallen)
            {
                StartCoroutine(GetUp(0.6f));
            }
            else
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
            gameObject.transform.up = new Vector3(1, 0, 0);
            fallen = true;
            Rigidbody2D rBody = gameObject.GetComponent<Rigidbody2D>();
            rBody.velocity = new Vector2(rBody.velocity.x, 4f);
        }
    }
}
