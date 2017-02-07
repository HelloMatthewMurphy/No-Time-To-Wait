using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Taken form stack overflow to test. Not used
public class ItemSway : MonoBehaviour {
    public static int TotalStacked;
    public float SwaySpeed;
    public float MaxAngle; //In degrees
    public int Swayer;
    int StackPlacement;
    bool RotateRight;

    void FixedUpdate()
    {
        if(StackPlacement == TotalStacked - Swayer)
        {
            if (RotateRight)
            {
                transform.Rotate(Vector3.right * SwaySpeed * Time.fixedDeltaTime);
            }
            else
            {
                transform.Rotate(-Vector3.right * SwaySpeed * Time.fixedDeltaTime);
            }

            if (Mathf.Abs(transform.eulerAngles.x) > 30)
            {
                RotateRight = !RotateRight;
            }
        }
    }

    bool Sticked;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == gameObject.tag)
        {
            if (!Sticked)
            {
                Vector3 Direction = transform.position - col.transform.position;

                if (Direction.y < (col.bounds.extents.y + col.bounds.extents.y))
                {
                    return;
                }
                else
                {
                    transform.parent = col.transform;
                    Sticked = true;
                    TotalStacked++;
                    StackPlacement = TotalStacked;
                }
            }
        }
    }
}