using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireingRate = 1f;
    private float timer;
    Rigidbody GunRb;
    void Start()
    {
        GunRb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot() {
        timer += Time.deltaTime;
        if (timer >= 1 / fireingRate)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = transform.forward * bulletSpeed + GunRb.velocity;
            timer = 0;
        }
    }
}