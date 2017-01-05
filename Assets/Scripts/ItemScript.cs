using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

    public GameObject itemStack;


	void Start () {
        itemStack = GameObject.FindGameObjectWithTag("ItemStack");
        this.transform.SetParent(itemStack.transform, true);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = itemStack.transform.rotation;
	}
}
