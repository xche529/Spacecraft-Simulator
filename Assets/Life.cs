using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class Life : MonoBehaviour
{
    public float health = 100f; // ����ֵ
    public GameObject deathEffect; // ������Ч

    public void TakeDamage(float damage)
    {
        health -= damage; // ��������ֵ

        if (health <= 0f)
        {
            Die(); // �������ֵС�ڵ��� 0��������
        }
    }

    private void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation); // ����������Ч
        }

        Destroy(gameObject); // ������Ϸ����
    }
}
