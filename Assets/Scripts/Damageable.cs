using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    protected float maxHealth = 100f;
    public float health = 100f;
    public Rigidbody rb;
    public Damageable() { }


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
        rb = this.GetComponent<Rigidbody>();
        // Check if the bullet collided with an object that can take damage
        Rigidbody target = collision.gameObject.GetComponent<Rigidbody>();
        if (target != null)
        {
            float damage = ((rb.mass + target.mass) * (target.velocity.magnitude + 1) * (rb.velocity.magnitude + 1)) / 100;
            // Apply damage to the collided object
            this.takeDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        rb = this.GetComponent<Rigidbody>();
        // Check if the bullet collided with an object that can take damage
        Rigidbody target = other.gameObject.GetComponent<Rigidbody>();
        if (target != null)
        {
            float damage = ((rb.mass + target.mass) * (target.velocity.magnitude + 1) * (rb.velocity.magnitude + 1)) / 100;
            // Apply damage to the collided object
            this.takeDamage(damage);
            if (other.gameObject.GetComponent<Damageable>() != null)
            {
                other.gameObject.GetComponent<Damageable>().takeDamage(damage);
            }
        }
    }
}
