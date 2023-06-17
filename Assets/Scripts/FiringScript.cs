using UnityEngine;

public class FiringScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireingRate = 1f;
    private float timer;
    Rigidbody GunRb;
    AudioSource soundEffect;
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();

        }
    }

    void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= 1 / fireingRate)
        {
            GunRb = GetParentRigidbody(transform);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = transform.forward * bulletSpeed + GunRb.velocity;
            timer = 0;
            soundEffect.Play();
        }
    }

    Rigidbody GetParentRigidbody(Transform childTransform)
    {
        Transform parentTransform = childTransform.parent;
        while (parentTransform != null)
        {  
            Rigidbody parentRb = parentTransform.GetComponent<Rigidbody>();
            if (parentRb != null)
            {
                return parentRb;
            }
            parentTransform = parentTransform.parent;
        }
        return null;
    }
}