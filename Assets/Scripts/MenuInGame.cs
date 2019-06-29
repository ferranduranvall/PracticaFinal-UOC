using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
 
    public GameObject MenuGame;
    public GameObject MessageIntro;


    private void Start()
    {
        MenuGame.SetActive(false);
        MessageIntro.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuGame.SetActive(true);
        }
    }

    public void DisableMenuInGame()
    {
        MenuGame.SetActive(false);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CloseInfo()
    {
        MessageIntro.SetActive(false);
    }
}