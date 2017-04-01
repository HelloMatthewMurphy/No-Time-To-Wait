using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    // Use this for initialization
    public GameObject speed;
    public GameObject glue;
    public GameObject banana;
    public float timeOfCooldown = 100.0f;
    public bool cooldown = true;
    public float maxNumOfPower;
    public float counter;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!cooldown)
        {
            timeOfCooldown -= Time.deltaTime;                         //Counts down time

            if (timeOfCooldown == 0.0f || timeOfCooldown <= 0.0f)   //If it reaches 0
            {
                cooldown = true;
            }
        }
        else
            timeOfCooldown = 0.1f;
        //gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text = timeOfCooldown.ToString("F1");
       // (gameObject.GetComponent(typeof(Collider2D)) as Collider2D).enabled = cooldown;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Kitchen" && cooldown && counter < maxNumOfPower)
        {

            GameObject powerUpToSpawn;
            Debug.Log("hit the kitchen");
            if (Random.value > 0.7)
            {
                Debug.Log("possible to spawn");
                if (Random.value < 0.33 && Random.value > 0)
                {

                    //powerUpToSpawn = speed;
                }
                else if (Random.value < 0.66 && Random.value > 0.33)
                {
                    //powerUpToSpawn = glue;
                }
                else
                {
                    //powerUpToSpawn = banana;
                }

                if (Random.value < 0.20 && Random.value > 0)
                {
                    Debug.Log("try to spawn");
                    powerUpToSpawn = Instantiate(banana, new Vector3(11.0f, -37.0f, 0f), Quaternion.identity);
                   // powerUpToSpawn.AddComponent<Rigidbody2D>();
                    timeOfCooldown = 10.0f;
                    counter += 1;

                }
                else if (Random.value < 0.39 && Random.value > 0.33)
                {
                    Debug.Log("try to spawn");
                    powerUpToSpawn = Instantiate(speed, new Vector3(20.0f, -37.0f, 0f), Quaternion.identity);
                    powerUpToSpawn.AddComponent<Rigidbody2D>();
                    timeOfCooldown = 10.0f;
                    counter += 1;
                }

                else if (Random.value > 0.8)
                {
                    Debug.Log("try to spawn");
                    powerUpToSpawn = Instantiate(glue, new Vector3(3.0f, -37.0f, 0f), Quaternion.identity);
                    powerUpToSpawn.AddComponent<Rigidbody2D>();
                    timeOfCooldown = 10.0f;
                    counter += 1;
                }


            }
        }

    }
}
