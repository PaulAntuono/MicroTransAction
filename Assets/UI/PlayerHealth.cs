using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;

    public float health;
    public float maxHealth;

    public Vector3 startingposition;
    // Start is called before the first frame update
    void Start()
    {
        startingposition = transform.position;
       health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();
        transform.position = startingposition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
