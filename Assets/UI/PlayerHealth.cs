using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;

    public float health;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
       health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
