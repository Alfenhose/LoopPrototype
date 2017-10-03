using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsometric : MonoBehaviour {

    private Rigidbody2D rigidbody;
    public float horizontalSpeed = 5;
    public float verticalSpeed = 5;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.velocity = new Vector2(PlayerInput.Instance.Horizontal * horizontalSpeed,
                                         PlayerInput.Instance.Vertical * verticalSpeed);
        SetDepth();

    }

    private void SetDepth()
    {
        float newZ = transform.position.y/100;
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }
}
