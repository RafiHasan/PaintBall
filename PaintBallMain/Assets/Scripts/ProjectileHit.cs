using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health < -0)
        {
            //Die();
            Debug.Log("hit!");
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
