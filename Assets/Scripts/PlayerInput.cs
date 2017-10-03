﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour {

    public static PlayerInput Instance;
    public float Horizontal;
    public float Vertical;

    public UnityEvent Up;
    public UnityEvent Down;
    public UnityEvent Right;
    public UnityEvent Left;

    public UnityEvent Jump;
    public UnityEvent Use;
    public UnityEvent Crouch;

    private bool jumping;
    private bool use;
    private bool crouch;

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        if (Input.GetAxis("Vertical") > 0.05)
        {
            Up.Invoke();
        }
        if (Input.GetAxis("Vertical") < -0.05)
        {
            Down.Invoke();
        }
        if (Input.GetAxis("Horizontal") > 0.05)
        {
            Right.Invoke();
        }
        if (Input.GetAxis("Horizontal") < -0.05)
        {
            Left.Invoke();
        }

        if (!jumping && Input.GetAxis("Vertical") > 0.05)
        {
            jumping = true;
            Jump.Invoke();
        }
        else
        {
            jumping = false;
        }
        if (!crouch && Input.GetAxis("Vertical") < -0.05)
        {
            crouch = true;
            Crouch.Invoke();
        }
        else
        {
            crouch = false;
        }
        if (!use && Input.GetAxis("Use") > 0.05)
        {
            use = true;
            Use.Invoke();
        }
        else
        {
            use = false;
        }
    }
}
