using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    Animator animAttack;
    public Collider katanaCollider;
    public GameObject katana;

    public AudioSource attackAudio;

    // Start is called before the first frame update
    void Awake()
    {
        animAttack = GetComponent<Animator>();
        katanaCollider = katana.GetComponent<Collider>();
        katanaCollider.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            animAttack.SetTrigger("AttackKatana");
            katanaCollider.enabled = true;
            attackAudio.Play();
        }
        else
        {
            katanaCollider.enabled = false;
        }

       
    }
}
