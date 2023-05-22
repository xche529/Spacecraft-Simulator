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
