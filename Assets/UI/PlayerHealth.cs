using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;

    public float health;
    public float maxHealth;
    

    public static Vector3 startingposition;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
       startingposition = transform.position;
       health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();
        transform.position = startingposition;
    }

    public void resetPlayerPos()
    {
        transform.position = startingposition;

    }

    public void Gameover()
    {
        SceneManager.LoadScene("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            transform.position = startingposition;
            Debug.Log(ScorePerSec.scoreValue);
            ScorePerSec.finalScore = ScorePerSec.scoreValue;
            Debug.Log(ScorePerSec.scoreValue);
            Debug.Log(ScorePerSec.finalScore);
            ScorePerSec.scoreValue = 0;
            Gameover();
            health = maxHealth;
            Debug.Log(ScorePerSec.finalScore);
        }
    }
}
