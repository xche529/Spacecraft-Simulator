using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform gunEnd; // 枪口位置
    public int damage = 10; // 武器的攻击力
    public float range = 100f; // 武器的攻击范围

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunEnd.position, gunEnd.forward, out hit, range))
        {
            // 如果击中了植物，则获取植物的 Life 组件，并调用 TakeDamage 方法
            Life life = hit.transform.GetComponent<Life>();
            if (life != null)
            {
                life.TakeDamage(damage);
            }
        }
    }
}
