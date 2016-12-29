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
    public bool standing;

    private float maxBodyAngle;

    // Use this for initialization
    void Start () {
        standing = true;
        rb = GetComponent<Rigidbody2D>();
        maxBodyAngle = Mathf.Abs(bodyGameObject.GetComponent<HingeJoint2D>().limits.max);  // gets the positive angle at which the body falls over
	}
    
	
	// Update is called once per frame
	void FixedUpdate () {
        float bodyRotation = bodyTransform.eulerAngles.z;
        if (bodyRotation > 180) // right side
        {
            bodyRotation = 360 - bodyRotation;
        }
        else    // left side
        {
            bodyRotation = -(bodyRotation);
        }

        //Debug.Log(bodyRotation);
        standing = Mathf.Abs(bodyRotation) >= maxBodyAngle;
        Debug.Log(standing);

        rb.AddForce(new Vector2(bodyRotation/82 * tiltSpeed, 0f));

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
