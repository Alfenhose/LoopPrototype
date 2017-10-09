using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour {

    public static PlayerInput Instance;
    public float Horizontal;
    public float Vertical;
    public string HorizontalAxisName = "Horizontal";
    public string VerticalAxisName = "Vertical";
    public string UseAxisName = "Use";
    public double deadZone = 0.05;

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
        Horizontal = Input.GetAxis(HorizontalAxisName);
        Vertical = Input.GetAxis(VerticalAxisName);

        if (Input.GetAxis(VerticalAxisName) > deadZone)
        {
            Up.Invoke();
        }
        if (Input.GetAxis(VerticalAxisName) < -deadZone)
        {
            Down.Invoke();
        }
        if (Input.GetAxis(HorizontalAxisName) > deadZone)
        {
            Right.Invoke();
        }
        if (Input.GetAxis(HorizontalAxisName) < -deadZone)
        {
            Left.Invoke();
        }

        if (Input.GetAxis(VerticalAxisName) > deadZone)
        {
            if (!jumping)
            {
                jumping = true;
                Jump.Invoke();
            }
        }
        else
        {
            jumping = false;
        }
        if (Input.GetAxis(VerticalAxisName) < -deadZone)
        {
            if (!crouch)
            {
                crouch = true;
                Crouch.Invoke();
            }
        }
        else
        {
            crouch = false;
        }
        if (Input.GetAxis(UseAxisName) > deadZone)
        {
            if (!use)
            {
                use = true;
                Use.Invoke();
            }
        }
        else
        {
            use = false;
        }
    }
}
