using System;
using UnityEngine;
using UnityEngine.UI;

public class ShipExample : Damageable, ControlableInterface
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 1f;
    public float maxForce = 10f;
    private Rigidbody shipRb;
    public Text speedText;
    public ParticleSystem particles;
    public Boolean isActive = false;

    void Start()
    {
        health = 100f;
        maxHealth = 100f;
        shipRb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (isActive)
        {
            Translate();
            Rotate();
            DisplayVelocity();
        }
    }

    public void Translate()
    {
        // transform the ship
        float horizontal = UnityEngine.Input.GetAxis("Horizontal");
        float vertical = UnityEngine.Input.GetAxis("Vertical");
        float lift = UnityEngine.Input.GetAxis("Lift");
        Vector3 movement = vertical * transform.forward + horizontal * transform.right - lift * transform.up;
        movement.Normalize();
        shipRb.AddForce(movement * moveSpeed * Time.deltaTime * 1000f);
        ParticleSystem.MainModule main = particles.main;
        main.startSize = vertical * 5f;
    }

    public void Rotate()
    {
        float mouseX = UnityEngine.Input.GetAxisRaw("Mouse X");
        float mouseY = UnityEngine.Input.GetAxisRaw("Mouse Y");
        float rotation = UnityEngine.Input.GetAxis("Rotate");
        // Rotate the ship
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime * 25 * rotationSpeed);
        transform.Rotate(Vector3.right, -mouseY * Time.deltaTime * 25 * rotationSpeed);
        transform.Rotate(Vector3.forward, -rotation * Time.deltaTime * 15 * rotationSpeed);
    }

    public void DisplayVelocity()
    {
        // display the velocity
        Vector3 velocity = shipRb.velocity;
        speedText.text = "Speed: X = " + velocity.x.ToString("F1") + " m/s, Y = " + velocity.y.ToString("F1") + " m/s, Z = " + velocity.z.ToString("F1") + " m/s, Life = " + this.health.ToString("F1");

    }

    public void SetActive()
    {
        this.isActive = true;
    }

    public void SetInactive()
    {
        this.isActive = false;
    }
}

