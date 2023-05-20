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
}
