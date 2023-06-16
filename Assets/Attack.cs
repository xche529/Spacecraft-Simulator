using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform gunEnd; // ǹ��λ��
    public int damage = 10; // �����Ĺ�����
    public float range = 100f; // �����Ĺ�����Χ

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
            // ���������ֲ����ȡֲ��� Life ����������� TakeDamage ����
            Life life = hit.transform.GetComponent<Life>();
            if (life != null)
            {
                life.TakeDamage(damage);
            }
        }
    }
}
