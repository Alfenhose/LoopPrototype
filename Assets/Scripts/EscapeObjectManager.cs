using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeObjectManager : MonoBehaviour {

    public Transform trashcan;
    public Transform ball;
    private float timer = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            switch (Random.Range(1, 3))
            {
                case 1:
                    Instantiate(trashcan, new Vector3(10, -4.35f, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(ball, new Vector3(10, -4.35f, 0), Quaternion.identity);
                    break;
            }
            timer = 3;
        }
	}
}
