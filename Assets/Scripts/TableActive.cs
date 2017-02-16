using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableActive : MonoBehaviour {
    
    public float tableWantTime;   //creates a random time for table to fill up
    public bool active = false;                         //boolean to see if table is active
    public bool peopleAtTable = false;
    public int numberAtTable = 0;

    // Use this for initialization
    void Start () {
        tableWantTime = Random.Range(1, 10);
    }
	
	// Update is called once per frame
	void Update () {
        if (!active && !peopleAtTable)
        {
            tableWantTime -= Time.deltaTime;                         //Counts down time

            if (tableWantTime == 0.0f || tableWantTime <= 0.0f)   //If it reaches 0
            {
                active = true;
                peopleAtTable = true;
            }
        }
        else if (active && peopleAtTable)
        {
            numberAtTable = Random.Range(1, 5);
            Debug.Log(numberAtTable);
            gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text = numberAtTable.ToString();
            active = false;
        }
    }
}
