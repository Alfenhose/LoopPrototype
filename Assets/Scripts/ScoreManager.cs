using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance;

    public float score;
    public float timeLeft = 60;
    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (UILevel1.Instance)
            UILevel1.Instance.time.text = "Time Left: "+(int)timeLeft;
        if (timeLeft <= -1)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
