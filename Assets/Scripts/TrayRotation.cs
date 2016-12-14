using UnityEngine;
using System.Collections;

public class TrayRotation : MonoBehaviour {

    public GameObject bodyGameObject;
    public GameObject positionOfTray;
    public GameObject tray;
    public Transform bodyTransform;
    public float rotatePrecent;

    // Use this for initialization
    void Start () {
        bodyGameObject = GameObject.FindGameObjectWithTag("Body");
        tray = GameObject.FindGameObjectWithTag("Tray");
        positionOfTray = GameObject.FindGameObjectWithTag("TrayPos");
    }
	
	// Update is called once per frame
	void Update () {
        float bodyRotation = bodyTransform.eulerAngles.z;
        if (bodyRotation > 180)
        {
            bodyRotation = -(360 - bodyRotation);
            //Debug.Log(bodyRotation);
        }
        else
        {
            bodyRotation = bodyRotation;
            //Debug.Log(bodyRotation);
        }
        transform.eulerAngles = new Vector3 (0, 0, bodyRotation * rotatePrecent);
        //if(tray.transform.rotation > 90)
        tray.transform.position = positionOfTray.transform.position;
    }
}
