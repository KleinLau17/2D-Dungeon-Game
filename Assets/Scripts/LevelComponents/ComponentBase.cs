using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentBase : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int damage = 1;

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        health.TakeDamage(damage);

        if (health.CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
