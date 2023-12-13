using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject bottom_bun;
    public GameObject bacon;
    public GameObject pickle;
    public GameObject cheese;
    public GameObject onion;
    public GameObject lettuce;
    public GameObject patty;
    public GameObject ketchup;
    public GameObject mayo;
    public GameObject top_bun;

    // Start is called before the first frame update
    void Start()
    {
        // Access the OrderDisplay instance and update the order display
        OrderDisplay o = OrderDisplay.Instance;
        if (o != null)
        {
            o.UpdateOrderDisplay();
        }
        else
        {
            Debug.LogError("OrderDisplay Instance not found!");
        }

        
        for (int i = 0; i < gameFlow.idx; i++ ) {
            if (gameFlow.plateValue[i] == 1) {
                GameObject newObject = Instantiate(bottom_bun, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
            else if (gameFlow.plateValue[i] == 2) {
                GameObject newObject = Instantiate(bacon, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
            else if (gameFlow.plateValue[i] == 3) {
                GameObject newObject = Instantiate(pickle, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
            else if (gameFlow.plateValue[i] == 4) {
                GameObject newObject = Instantiate(cheese, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
            else if (gameFlow.plateValue[i] == 5) {
                GameObject newObject = Instantiate(onion, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
            else if (gameFlow.plateValue[i] == 6) {
                GameObject newObject = Instantiate(lettuce, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
            else if (gameFlow.plateValue[i] == 7) {
                GameObject newObject = Instantiate(patty, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
            else if (gameFlow.plateValue[i] == 8) {
                GameObject newObject = Instantiate(ketchup, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
            else if (gameFlow.plateValue[i] == 9) {
                GameObject newObject = Instantiate(mayo, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
            else if (gameFlow.plateValue[i] == 10) {
                GameObject newObject = Instantiate(top_bun, new Vector3(0f,0.15f,0f), Quaternion.identity);
                newObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
