using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePerSec : MonoBehaviour
{
    // Singleton instance
    private static ScorePerSec _instance;
    public static ScorePerSec Instance
    {
        get
        {
            if (_instance == null)
            {
                // If the instance doesn't exist, find it in the scene
                _instance = FindObjectOfType<ScorePerSec>();

                // If it still doesn't exist, create a new instance
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("ScoreManager");
                    _instance = singletonObject.AddComponent<ScorePerSec>();
                }
            }
            return _instance;
        }
    }

    public TMP_Text ScoreValueText;
    public TMP_Text FinalScore;
    public static float finalScore = 0;
    public static float scoreValue = 0;
    public float scorePerSec = 1f;

    void Awake()
    {
        // Ensure there is only one instance of ScorePerSec in the scene
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ScoreValueText.text = ("Score: " + (int)scoreValue).ToString();
        //scoreValue += scorePerSec * Time.fixedDeltaTime;
    }
}
