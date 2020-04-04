using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public CharacterController character;
    public float survivalTimer = .5f; //the time that the player can spend in the air without taking damage
    public float damagePerSecond = 100f; //damage taken for 1 second in air (for airTime = 1)

    public float currentHealth { get; set; }

    private float maxHealth = 100;
    private float airTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!character.IsGrounded)
        {
            airTime += Time.deltaTime;
        }

        if (character.IsGrounded == true && airTime > survivalTimer)
        {
            currentHealth -= damagePerSecond * airTime;
            airTime = 0;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameManager.Instance.GameOver();
    }
}
