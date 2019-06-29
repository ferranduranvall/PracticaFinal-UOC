using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGame : MonoBehaviour
{
    public GameObject zombies1,zombies2,zombies3, zombies4, zombies5, zombies6, zombies7, zombies8, zombies9, zombies10, zombies11, zombies12;

    // Start is called before the first frame update
    void Start()
    {
        //zombies = GameObject.FindGameObjectsWithTag("Zombie");
    }

    // Update is called once per frame
    void Update()
    {
        if(zombies1 == null && zombies2 == null && zombies3 == null && zombies4 == null && zombies5 == null && zombies6 == null & zombies7 == null 
            && zombies8 == null && zombies9 == null && zombies10 == null && zombies11 == null && zombies12 == null)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
