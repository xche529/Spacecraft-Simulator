using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifetime = 2f;
    private float timer;
    public float damage = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = Quaternion.Euler(90f, 0f, 90f);
        GetComponent<Rigidbody>().MoveRotation(rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collided with an object that can take damage
        HealthSystem target = collision.gameObject.GetComponent<HealthSystem>();
        if (target != null)
        {
            // Apply damage to the collided object
            target.TakeDamage(damage);
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}


// Update is called once per frame
void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
