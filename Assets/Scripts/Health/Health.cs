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

    private RobotCharacter robotCharacter;
    private RobotController robotController;
    private new Collider2D collider2D;
    private SpriteRenderer spriteRenderer;

    

    public float CurrentHealth { get; set; }

    private void Awake()
    {
        robotController = GetComponent<RobotController>();
        robotCharacter = GetComponent<RobotCharacter>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        CurrentHealth = initialHealth;

        
    }

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(1);
        }
        
    }

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

    private void Die()
    {
        if (robotCharacter != null)
        {
            collider2D.enabled = false;
            spriteRenderer.enabled = false;

            robotCharacter.enabled = false;
            robotController.enabled = false;


        }

        if (destroyObject)
        {
            DestroyObject();
        }

    }

    public void Revive()
    {
        if (robotCharacter != null)
        {
            collider2D.enabled = true;
            spriteRenderer.enabled = true;

            robotCharacter.enabled = true;
            robotController.enabled = true;

        }

        gameObject.SetActive(true);

        CurrentHealth = initialHealth;

    }

    private void DestroyObject()
    {
        gameObject.SetActive(false);

    }

    
}
