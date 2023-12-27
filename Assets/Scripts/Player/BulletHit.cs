using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float weaponDamge;
    
    ProjecttileControler myPC;
    // khai bao file khac

    private void Awake()
    {
        myPC = GetComponentInParent<ProjecttileControler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Quai")
        {
            // khi ban quai se xoa quai
            myPC.removeForce();

            Destroy(gameObject);

            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamge(weaponDamge);
                Shared.scores++;

            }

        }
    }




}
