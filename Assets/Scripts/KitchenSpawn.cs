using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenSpawn : MonoBehaviour {

    public float kitchenSpawnTime = 2.0f;       //Time for food to be cooked
    public bool foodReady = true;               //Is the food ready?

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!foodReady)
        {
            kitchenSpawnTime -= Time.deltaTime;                         //Counts down time

            if (kitchenSpawnTime == 0.0f || kitchenSpawnTime <= 0.0f)   //If it reaches 0
            {
                foodReady = true;
            }
        }
        else
            kitchenSpawnTime = 0.1f;
        gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text = kitchenSpawnTime.ToString("F1");
        (gameObject.GetComponent(typeof(Collider2D)) as Collider2D).enabled = foodReady;
	}
}
