using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public List<GameObject> itemsOnTray = new List<GameObject>();
    public GameObject item; //Item that will be on tray
    public GameObject trayPos;
    //public GameObject tray;
    public int maxAmount;
    private int currentAmount;
    private float i = 0;
    private float time = 0.2f;

    // Use this for initialization
    void Start () {
        trayPos = GameObject.FindGameObjectWithTag("TrayPos");
        //tray = GameObject.FindGameObjectWithTag("Tray");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //When hit kitchen take food
        if (col.gameObject.tag == "Kitchen" && currentAmount < maxAmount)
        {
            Debug.Log("Collision");
            Object[] subListObjects = Resources.LoadAll("Items", typeof(GameObject));
            Debug.Log(subListObjects[0].name);

            foreach (GameObject subListObject in subListObjects)
            {
                Debug.Log("AddingToList");
                GameObject temp = (GameObject)subListObject;
                if (temp.transform.tag == "FoodItem")
                {
                    itemsOnTray.Add(Instantiate(item, trayPos.transform.position + new Vector3(0, 0 + i, 0), Quaternion.identity));
                    Debug.Log("GOT FOOD BOI!!!");

                    //Instantiate(item, trayPos.transform.position + new Vector3(0, 0 + i, 0), Quaternion.identity);
                    i += 0.1f;
                    currentAmount++;
                }
            }
        }

        //When hit table remove food
        if (col.gameObject.tag == "Table" && currentAmount > 0)
        {
            Debug.Log("Remove IT BOIIIIII");
            //Object[] subListObjects = Resources.LoadAll("Items", typeof(GameObject));
            //Debug.Log(subListObjects[0].name);
            Destroy(itemsOnTray[itemsOnTray.Count - 1], time);
            //itemsOnTray[itemsOnTray.Count - 1].SetActive(false);
            itemsOnTray.Remove(itemsOnTray[itemsOnTray.Count - 1]);
            //DestroyImmediate(itemsOnTray[itemsOnTray.Count - 1], true);
            currentAmount--;

        }
    }
}
