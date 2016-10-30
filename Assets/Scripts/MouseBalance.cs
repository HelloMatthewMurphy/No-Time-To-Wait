using UnityEngine;
using System.Collections;

public class MouseBalance : MonoBehaviour
{

    public float rotationSpeed;             // How sensitive the torque is applied
    public float rotationSpeedLimit;        // Fastest speed the body can rotate at
    public float rotationDeccelerationRate; // If no input is given, how fast players balancing input looses speed

    private float rotationAcceleration;     // How much torque it's applying
    private float accelerationLimit;        // Max torque acceleration
    private float rotationDecceleration;

    // Use this for initialization
    void Start()
    {
        rotationAcceleration = 0;
        accelerationLimit = 10;
        rotationDecceleration = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        applyRotation();
    }

    private void applyRotation()
    {
        rotationAcceleration += Input.GetAxis("Horizontal");
        //rotationAcceleration += Input.GetAxis("Horizontal");
        rotationAcceleration = Mathf.Clamp(rotationAcceleration, -accelerationLimit, accelerationLimit);

        GetComponent<Rigidbody2D>().AddTorque(rotationAcceleration * rotationSpeed * Time.deltaTime);
        GetComponent<Rigidbody2D>().angularVelocity = Mathf.Clamp(GetComponent<Rigidbody2D>().angularVelocity, -rotationSpeedLimit, rotationSpeedLimit);

        if (Input.GetAxis("Horizontal") == 0) // if mouse is not moved, deccelerate it
        //if (Input.GetAxis("Horizontal") == 0) // if mouse is not moved, deccelerate it
        {
            /*
            rotationAcceleration = Mathf.Lerp(rotationAcceleration, 0, 0.05f);
            Debug.Log(rotationAcceleration);
            //*/
            if (rotationAcceleration < -accelerationLimit * 0.1)    // if the acceleration is higher than 10% of the limit
            {
                rotationAcceleration += rotationDecceleration;
            }
            else if (rotationAcceleration > accelerationLimit * 0.1)
            {
                rotationAcceleration -= rotationDecceleration;
            }
            rotationDecceleration += rotationDeccelerationRate;
        }
        else
        {
            rotationDecceleration = 0;
        }
    }
}
