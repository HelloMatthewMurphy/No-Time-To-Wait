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
    public bool enableFalling;

    private float maxBodyAngle;
    private MouseBalance mouseBalanceScript;
    private Vector2 respawnLocation;    // location where the player will respawn after falling down
    private bool fallingExecuted;

    // Use this for initialization
    void Start () {
        standing = true;
        rb = GetComponent<Rigidbody2D>();
        maxBodyAngle = Mathf.Abs(bodyGameObject.GetComponent<HingeJoint2D>().limits.max);  // gets the positive angle at which the body falls over
        mouseBalanceScript = bodyGameObject.GetComponent<MouseBalance>();
    }
    
	
	// Update is called once per frame
	void FixedUpdate () {
        float bodyRotation = bodyTransform.eulerAngles.z;
        if (bodyRotation > 180) // right side
        {
            bodyRotation = 360 - bodyRotation;
        }
        else                    // left side
        {
            bodyRotation = -(bodyRotation);
        }

        if (standing && enableFalling)
        {
            standing = Mathf.Abs(bodyRotation) < maxBodyAngle;  // false if body is tilting beyond max body angle
        }

        if (standing)
        {
            applyMovement(bodyRotation);

            fallingExecuted = false;
        }
        else if (!fallingExecuted)   // only executes once
        {
            fallOver();
            fallingExecuted = true;
            //Invoke("standUp", 2f);
        }
    }

    private void fallOver()
    {
        respawnLocation = transform.position;           // records the position where the player fell over

        mouseBalanceScript.setEnableRotation(false);    // removes rotation control
        rb.constraints = RigidbodyConstraints2D.None;   // lets the legs fall over like a ragdoll
        bodyGameObject.GetComponent<BoxCollider2D>().isTrigger = false; // turns the bodies hitbox into non-trigger meaning its collision is on
    }

    private void standUp()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void applyMovement(float bodyRotation)
    {
        rb.AddForce(new Vector2(bodyRotation / (maxBodyAngle + 2) * tiltSpeed, 0f)); // can't remember what + 2 is for. Too afraid to change it at this point

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
