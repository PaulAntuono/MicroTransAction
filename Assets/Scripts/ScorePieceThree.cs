using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePieceThree : MonoBehaviour
{
    public ScorePerSec ScoreCount;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            ScoreCount.scoreValue += 500;
            Destroy(gameObject);
        }
    }

}