using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePerSec : MonoBehaviour
{
    public Text ScoreValueText;
    public float scoreValue = 0;
    public float scorePerSec = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        ScoreValueText.text = ("Score: " + (int)scoreValue).ToString();
        scoreValue += scorePerSec * Time.fixedDeltaTime;
    }
}
