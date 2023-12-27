using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
 //   public Text txtCoin;
    public AudioSource sound_coin;
    public float maxHealth;
    float currenHealth;
    Animator myAnim;
    public Slider enemyHealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        currenHealth = maxHealth;
        myAnim = GetComponent<Animator>();
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
    }

  
    public void addDamge(float damage)
    {
        enemyHealthSlider.gameObject.SetActive(true);
        currenHealth -= damage;
        enemyHealthSlider.value = currenHealth;
        if (currenHealth <= 0)
        {
     //       myAnim.SetBool("death", true);
            makeDead();
            Shared.scores++;
        }
        // nhan dame khi player ban va chet
    }

    void makeDead()
    {

        Destroy(gameObject);


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gate")
        { // lay ten cong vao,  string nameGate =   collision.gameObject.name;
            SceneManager.LoadScene("vong2");
            // qua vong
        }
    }
}
