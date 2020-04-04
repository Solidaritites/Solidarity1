using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private float maxHealth = 100;
    public float currentHealth;
    public float minSurviveFall = 0f; //the time that the player can spend in the air without taking damage
    public float damageForSeconds = 100f; //damage taken for 1 second in air (for airTime = 1)
    private float airTime = 0;
    private CharacterController cController;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        cController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(cController.isGrounded == false)
        {
            airTime += Time.deltaTime;
        }

        if(cController.isGrounded == true && airTime > minSurviveFall)
        {
            currentHealth -= damageForSeconds * airTime;
            airTime = 0;
        } 

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameManager.Instance.GameOver();
    }
}
