using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour {

    public static Events Instance;
    //public UnityEvent Fallen;
    //public UnityEvent GottenUp;
    public float scrollSpeed = -3f;

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

    public void InvokeFallen()
    {
        //Fallen.Invoke();
        scrollSpeed = 0;
    }

    public void InvokeGottenUp()
    {
        //GottenUp.Invoke();
        scrollSpeed = -3;
    }
}
