using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

    public GameObject itemStack;
    public bool fallen;

	void Start () {
        itemStack = GameObject.FindGameObjectWithTag("ItemStack");      //Gets stack to put items on
        this.transform.rotation = itemStack.transform.rotation;         //Sets items roatation to same as stack
        this.transform.SetParent(itemStack.transform, true);            //Makes item child of stack
        fallen = false;                                                 //True if the item has fallen from the tray
    }
	
	// Update is called once per frame
	void Update () {
        if (!fallen)
        {
            this.transform.rotation = itemStack.transform.rotation;         //Updates items rotation to be same as stack
        }
	}
}
