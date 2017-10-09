using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StealingLevel()
    {
        SceneManager.LoadScene("Mikkel");
    }
    public void EscapingLevel()
    {
        SceneManager.LoadScene("Ast Loop 2");
    }
}
