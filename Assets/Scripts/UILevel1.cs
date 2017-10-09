using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel1 : MonoBehaviour {

    public Text score;
    public Text highscore;
    public Text time;
    public Text justStole;
    public Image justImage;
    public Text justWorth;
    public static UILevel1 Instance;
    public GameObject JustStolePanel;
    
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
            
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ScoreManager.Instance.score > PlayerPrefs.GetFloat("highscore", 0))
        {
            PlayerPrefs.SetFloat("highscore", ScoreManager.Instance.score);
        }
        score.text = "Score:" + ScoreManager.Instance.score;
        highscore.text = "Highscore:" + PlayerPrefs.GetFloat("highscore",0);

        if (lastPickedUp)
        {
            justStole.text = "You just stole " + lastPickedUp.objectName;
            justImage.sprite = lastPickedUp.spriterenderer.sprite;
            justWorth.text = "Worth $" + lastPickedUp.worth;
        }
	}
    public void ShowStolePanel(bool value)
    {
        JustStolePanel.SetActive(value);
    }
}
