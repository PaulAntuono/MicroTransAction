using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeartManager : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerHealth playerHealth;
    List<HeartScript> hearts = new List<HeartScript>();

    
    private void Start()
    {
        DrawHearts();
    }

    private void Update()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHearts();


        float maxHealthRemainder = playerHealth.maxHealth % 2;
        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);

        for(int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }
       
        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
                
        }
        

    }
    

    public void CreateEmptyHeart()
    {

        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HeartScript heartComponent = newHeart.GetComponent<HeartScript>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {

        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);

        }
        hearts = new List<HeartScript>();
    }


}
