using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float tiltSpeed; // How fast the player moves based on the angle
    public MouseBalance bodyMouseBalanceScript;
    public GameObject bodyGameObject;
    public Transform bodyTransform;
    private Rigidbody2D rb;
    public float maxSpeed = 3f;
    public float moveSpeed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
    
	
	// Update is called once per frame
	void FixedUpdate () {
        float bodyRotation = bodyTransform.eulerAngles.z;
        //Debug.Log(bodyRotation);
        if (bodyRotation > 180)
        {
            bodyRotation = 360 - bodyRotation;
        }
        else
        {
            bodyRotation = -(bodyRotation);
        }
        rb.AddForce(new Vector2(bodyRotation/82 * tiltSpeed, 0f));

        /*
        if (Input.GetAxis("HorizontalP") < 0f) 			// facing left
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxis("HorizontalP") > 0f)	// facing right
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/

        Vector3 easeVelocity = rb.velocity;
        easeVelocity.y = rb.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("HorizontalP");
        
        rb.velocity = easeVelocity;

        // moves player
        rb.AddForce((Vector2.right * moveSpeed) * h);

        // Limit speed
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }
}
