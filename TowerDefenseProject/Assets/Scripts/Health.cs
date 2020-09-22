using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float startingHealth = 500f;
    [SerializeField] GameObject DeathVFX;
    [SerializeField] float timeToDestroyVFX = 0.35f;
    float currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void DealDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            // Play VFX
            TriggerDeathVFX();
            // destroy
            Destroy(gameObject);
            
        }
    }

    private void TriggerDeathVFX()
    {
        if(!DeathVFX) { return; }
        var spawnedVFX = Instantiate(DeathVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(spawnedVFX, timeToDestroyVFX);
    }
}
