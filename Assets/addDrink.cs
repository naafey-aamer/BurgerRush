using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addDrink : MonoBehaviour
{
    public GameObject objectToAdd;
    public int foodValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        if (cookManagerGameFlow.currDrink != null) {
            Destroy(cookManagerGameFlow.currDrink);
        }
        
        GameObject newObject = Instantiate(objectToAdd, new Vector3(0.146f,-0.02f,-0.274f), Quaternion.identity);
        newObject.SetActive(true); // spawn object above tray 
        cookManagerGameFlow.currDrink = newObject;

        // gameFlow.plateValue[gameFlow.idx] = foodValue;
        // gameFlow.idx = gameFlow.idx + 1;
        // Debug.Log("Array Contents: " + string.Join(", ", gameFlow.plateValue));
    }
}
