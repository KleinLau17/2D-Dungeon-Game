using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    [Header("Settings")]
    [SerializeField] private bool destroyObject;

    private Character character;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;

    // Controls the current health of the object    
    public float CurrentHealth { get; set; }

    private void Awake()
    {
        character = GetComponent<Character>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        CurrentHealth = initialHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
    }

    // Take the amount of damage we pass in parameters
    public void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0)
        {
            return;
        }

        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    // Kills the game object
    private void Die()
    {
        if (character != null)
        {
            collider2D.enabled = false;
            spriteRenderer.enabled = false;
        }

        if (destroyObject)
        {
            DestroyObject();
        }
    }

    // Revive this game object    
    public void Revive()
    {

    }

    // If destroyObject is selected, we destroy this game object
    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
