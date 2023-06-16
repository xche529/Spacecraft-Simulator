using UnityEngine;

public class Life : MonoBehaviour
{
    public float health = 100f; // 生命值
    public GameObject deathEffect; // 死亡特效

    public void TakeDamage(float damage)
    {
        health -= damage; // 减少生命值

        if (health <= 0f)
        {
            Die(); // 如果生命值小于等于 0，则死亡
        }
    }

    private void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, transform.rotation); // 播放死亡特效
        }

        Destroy(gameObject); // 销毁游戏对象
    }
}
