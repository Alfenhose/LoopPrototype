using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscapeObjectManager : MonoBehaviour {

    public static EscapeObjectManager Instance;
    public Transform trashcan;
    public Transform ball;
    private float timer = 0;
    public Text endText;
    public bool gameEnded = false;

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

    public void EndGame(bool playerWon)
    {
        if (playerWon)
        {
            endText.text = "You escaped!";
        } else
        {
            endText.text = "You got caught!";
        }
        gameEnded = true;
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
}
