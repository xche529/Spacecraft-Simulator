using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    protected float maxHealth = 100f; 
    public float health = 100f;
    public Damageable(){}

    public void setHealth(float health)
    {
        this.health = health;
    }

    public float getHealth()
    {
        return health;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    public void gethealth(float health)
    {
        this.health += health;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {   
        // Check if the bullet collided with an object that can take damage
        Rigidbody target = collision.gameObject.GetComponent<Rigidbody>();
        if (target != null)
        {
            float damage = target.mass* target.velocity.magnitude;
            // Apply damage to the collided object
            this.takeDamage(damage);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}
