using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombiesAttack : MonoBehaviour
{
    public GameObject player;                          // Reference to the player GameObject.
    public PlayerHealth playerHealth;                  // Reference to the player's health.
    public int attackDamage = 1;

    public Animator anim;
    public GameObject zombie;

    public AudioSource audioZombie;

    private void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = zombie.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player3rd")
        {

            // If the player has health to lose...
            if (playerHealth.currentHealth > 0)
            {
                // ... damage the player.
                playerHealth.TakeDamage(attackDamage);

                //put here animation zombie attacking player
                anim.SetTrigger("AttackPlayer");

                audioZombie.Play();
            }
        }
    }

}
