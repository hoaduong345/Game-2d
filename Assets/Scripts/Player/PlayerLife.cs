
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerLife : MonoBehaviour
{
   
    public Rigidbody2D rb;
    public Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;
    private object platformCollider;
    private object playerCollider;


    public void Start()
    {
        anim = GetComponent<Animator>();
       
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Trap")
        {
            HealthManager.health--;
            if (HealthManager.health == 0)
            {
                
                PlayerManagement.isGameOver = true;              
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }

        if (collision.transform.tag == "Quai")
        {
            HealthManager.health--;
            if (HealthManager.health == 0)
            {

                PlayerManagement.isGameOver = true;
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }

    }

   

    IEnumerator GetHurt()
    {
        
        deathSoundEffect.Play();
        Physics2D.IgnoreLayerCollision(6,8);
        anim.SetLayerWeight(1, 0);
        yield return new WaitForSeconds(3);
        anim.SetLayerWeight(1, 1);
        Physics2D.IgnoreLayerCollision(6,8, false);
        
    }
}
