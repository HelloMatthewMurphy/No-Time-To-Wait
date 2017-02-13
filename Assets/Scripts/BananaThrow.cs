using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaThrow : MonoBehaviour
{

    public float floatMovementHeight;   // max distance a power up can move in a single frame
    public int floatCycles;             // higher number = slower floating
    //public PlayerMovement movementScript;
    public GameObject bannana;
    public GameObject body;
    private int currentCycle;

    // Use this for initialization
    void Start()
    {
        currentCycle = 0;
    }

    // Update is called once per frame
    void Update()
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

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Throw"))
        {
            body = GameObject.FindGameObjectWithTag("Body");
            //bannana.transform.parent = body.transform;
            Instantiate(bannana, body.transform,false);
            Destroy(gameObject);
        }
    }
}
