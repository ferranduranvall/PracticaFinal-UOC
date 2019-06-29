using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject katana;
    public GameObject car;
    public GameObject particles;
    public GameObject zombie;

    public ParticleSystem blood;
    public AudioSource splashBlood;

    public int scoreValue = 10;

    public static int score;        // The player's score.
    public Text text;               // Reference to the Text component.
    public GameObject textScore;



    private void Awake()
    {
        blood = particles.GetComponent<ParticleSystem>();
        // Set up the reference.
        text = textScore.GetComponent<Text>();
    
        // Reset the score.
        score = 0;
    }

    private void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Zombies Score: " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == katana)
        {
            blood.Play();
            splashBlood.Play();
            Destroy(zombie,1);
            Death();
            
        }

        if (other.gameObject == car)
        {
           
            blood.Play();
            splashBlood.Play();
            Destroy(zombie, 1);
            Death();
        }

    }

    void Death()
    {
        //ScoreManager.score += scoreValue;
        score = score+scoreValue;
    }
}
