using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour {

    static PlayerInput Instance;
    public float Player1_Horizontal;
    public float Player1_Vertical;
    public float Player2_Horizontal;
    public float Player2_Vertical;
    public UnityEvent Player1_Jump;
    public UnityEvent Player2_Jump;
    public UnityEvent Player1_Use;
    public UnityEvent Player2_Use;

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
		
	}
}
