using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp: MonoBehaviour
{

    public float floatMovementHeight;   // max distance a power up can move in a single frame
    public int floatCycles;             // higher number = slower floating
    public PlayerMovement movementScript;
   // public PlayerMovement movementScript1;
    private int currentCycle;

	// Use this for initialization
	void Start ()
    {
        currentCycle = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 updatedPos = transform.position;    // gets the current position of the power up
        updatedPos.y = updatedPos.y + (floatMovementHeight * Mathf.Cos(Mathf.PI * 2.0f * (1.0f * currentCycle / floatCycles))); // adds or takes away a small amount of distance. This gives an illusion of it floating up and down. Sin function makes the movement smooth

        transform.position = updatedPos;            // changes the position of the power up to this newly calculated position

        currentCycle++;

        if (currentCycle == floatCycles)            // resets the cycle once it reaches the max cycle (floatCycles)
        {
            currentCycle = 0;
        }
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Body" || collision.gameObject.tag == "Legs") 
            && movementScript.getStanding())   // if the player touches the power up and is standing
        {
            movementScript.setSpeed(3, 3);
            Destroy(gameObject);    // destroys the game object, making it disappear
            //Invoke(movementScript.setSpeed(1 / 3, 1 / 3), 5);
        }
    }
}
