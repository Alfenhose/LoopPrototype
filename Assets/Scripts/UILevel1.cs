using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel1 : MonoBehaviour {

    public Text score;
    public Text justStole;
    public Text justWorth;
    public static UILevel1 Instance;
    
    public IsometricObject lastPickedUp;
    // Use this for initialization
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
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score:" + ScoreManager.Instance.score;

        if (lastPickedUp)
        {
            justStole.text = "You just stole " + lastPickedUp.objectName;
            justWorth.text = "Worth $" + lastPickedUp.worth;
        }
	}
}
