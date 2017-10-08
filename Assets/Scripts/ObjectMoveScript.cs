using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveScript : MonoBehaviour {

    private Rigidbody2D rBody;
    public float moveSpeed = -5;
    public float fallingModifier = 5;
    private bool knockedOver = false;
    private Events events;
    private bool fallen;
    private bool gettingUp;

    // Use this for initialization
    void Start ()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        events = Events.Instance;
        //events.Fallen.AddListener(Fallen);
        //events.GottenUp.AddListener(GottenUp);
    }

    // Update is called once per frame
    void Update () {
        Move();
	}

    private void Move()
    {
        //if (fallen)
        //{
        //    rBody.velocity = new Vector2(Mathf.MoveTowards(rBody.velocity.x, 0, fallingModifier * Time.deltaTime), rBody.velocity.y);
        //} else if (gettingUp)
        //{
        //    rBody.velocity = new Vector2(Mathf.MoveTowards(rBody.velocity.x, moveSpeed, fallingModifier * Time.deltaTime), rBody.velocity.y);
        //} else
        //{
        //    rBody.velocity = new Vector3(moveSpeed, 0, 0);
        //}
        rBody.velocity = new Vector2(Mathf.MoveTowards(rBody.velocity.x, events.scrollSpeed, fallingModifier * Time.deltaTime), rBody.velocity.y);
    }

    public void Collision()
    {
        if(gameObject.tag == "KnockOverAble" && !knockedOver)
        {
            gameObject.transform.up = new Vector3(1, 0, 0);
            gameObject.transform.position += new Vector3(0, -0.19f , 0);
            knockedOver = true;
        }
    }

    private void Fallen()
    {
        fallen = true;
    }

    private void GottenUp()
    {
        fallen = false;
        gettingUp = true;
    }

    IEnumerator GettingUp()
    {
        yield return new WaitForSeconds(1);
        gettingUp = false;
    }

}
