using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class ShipExample : Damageable
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 1f;
    public float maxForce = 10f;
    private Rigidbody shipRb;
    public Text speedText;
    public ParticleSystem particles;

    void Start()
    {
        health = 100f;
        maxHealth = 100f;
    }

    void Update()
    {
        // get input from player
        float horizontal = UnityEngine.Input.GetAxis("Horizontal");
        float vertical = UnityEngine.Input.GetAxis("Vertical");
        float mouseX = UnityEngine.Input.GetAxisRaw("Mouse X")  ;
        float mouseY = UnityEngine.Input.GetAxisRaw("Mouse Y") ;
        float rotation = UnityEngine.Input.GetAxis("Rotate");
        float lift = UnityEngine.Input.GetAxis("Lift");
        
        // transform the ship
        Vector3 movement = vertical * transform.forward + horizontal * transform.right - lift * transform.up;
        movement.Normalize();
        shipRb.AddForce(movement * moveSpeed * Time.deltaTime);


        // Rotate the ship
        transform.Rotate( Vector3.up, mouseX * Time.deltaTime * 25 * rotationSpeed);
        transform.Rotate(Vector3.right, -mouseY * Time.deltaTime * 25 * rotationSpeed);
        transform.Rotate(Vector3.forward, -rotation * Time.deltaTime * 15 * rotationSpeed);
        ParticleSystem.MainModule main = particles.main;
        main.startSize = vertical * 5f;

        // display the velocity
        Vector3 velocity = shipRb.velocity;
        speedText.text = "Speed: X = " + velocity.x.ToString("F1") + " m/s, Y = " + velocity.y.ToString("F1") + " m/s, Z = " + velocity.z.ToString("F1") + " m/s";
    }

}

