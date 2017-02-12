using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public List<GameObject> itemsOnTray = new List<GameObject>();
    public GameObject item; //Item that will be on tray
    public GameObject trayPos;
    public ScoreForPlayer parent; //Used to change score in parent
    public int maxAmount;
    public float foodDist;  // Distance between food pieces (from the center of 1 food unit to the center of the next food unit)
    public int currentAmount;

    private float time = 0.2f;

    // Use this for initialization
    void Start () {
        trayPos = GameObject.FindGameObjectWithTag("TrayPos");
        //tray = GameObject.FindGameObjectWithTag("Tray");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerStay2D(Collider2D col)
    {
        //When hit kitchen take food
        if (col.gameObject.tag == "Kitchen" && currentAmount < maxAmount)
        {
            //Debug.Log("Collision");
            Object[] subListObjects = Resources.LoadAll("Items", typeof(GameObject));
            //Debug.Log(subListObjects[0].name);

            foreach (GameObject subListObject in subListObjects)
            {
                //Debug.Log("AddingToList");
                GameObject temp = (GameObject)subListObject;
                if (temp.transform.tag == "FoodItem")
                {
                    itemsOnTray.Add(Instantiate(item, transform.position + (transform.up * foodDist * (itemsOnTray.Count + 1)), Quaternion.identity));   // spawn food unit on the tray with appropriate foodDist
                    currentAmount++;
                }
            }
        }

        //When hit table remove food
        if (col.gameObject.tag == "Table" && currentAmount > 0)
        {
            Destroy(itemsOnTray[itemsOnTray.Count - 1], time);
            itemsOnTray.Remove(itemsOnTray[itemsOnTray.Count - 1]);
            currentAmount--;
            parent.score++;
        }
    }
}
