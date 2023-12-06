using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScorePieceOne : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            ScorePerSec.scoreValue += 50;
            Destroy(gameObject);
        }
    }

}
