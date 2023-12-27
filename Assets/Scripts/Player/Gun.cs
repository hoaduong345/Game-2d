using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunTip;  // khai bao sung
    public GameObject bullet; // khai bao vien dan
    float fireRate = 0.5f;  // toc do ban
    float nextFire = 0;  // ban dc nhieu lan sau
    [SerializeField] private AudioSource fireSoundEffect;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            fireBullet();

        }
    }
    void fireBullet()
    {
        // Fire1 tuong duong vs nut chuot trai
        // chuot trai se ban
        // ban dan xoay mat theo chieu
        if (Time.time > nextFire)
        {
            fireSoundEffect.Play();
            nextFire = Time.time + fireRate;
            
            Instantiate(bullet, gunTip.position, gunTip.rotation);

        }
    }
}
