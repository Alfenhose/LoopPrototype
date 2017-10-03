using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIsometric : MonoBehaviour {

    private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.velocity = new Vector2(PlayerInput.Instance.Horizontal, PlayerInput.Instance.Vertical);
	}
}
