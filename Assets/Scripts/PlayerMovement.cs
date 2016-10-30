using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed; // How fast the player moves based on the angle
    public MouseBalance bodyMouseBalanceScript;
    public GameObject bodyGameObject;
    public Transform bodyTransform;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float bodyRotation = bodyTransform.eulerAngles.z;
        Debug.Log(bodyRotation);
        if (bodyRotation > 180)
        {
            bodyRotation = 360 - bodyRotation;
        }
        else
        {
            bodyRotation = -(bodyRotation);
        }
        rb.AddForce(new Vector2(bodyRotation/82 * movementSpeed, 0f));
    }
}
