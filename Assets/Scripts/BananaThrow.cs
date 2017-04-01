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
    public string throwInput = "Throw_P1";

    private int currentCycle;

    // Use this for initialization
    void Start()
    {
        currentCycle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown(throwInput))
        {
            GameObject bananaInstance = Instantiate(bannana, body.transform ,false);
            bananaInstance.AddComponent<Rigidbody2D>();
            bananaInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 200f));
            bananaInstance.transform.SetParent(null);

            Destroy(gameObject);
        }
    }
}
