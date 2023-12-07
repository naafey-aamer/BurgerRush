using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addFries : MonoBehaviour
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
        if (cookManagerGameFlow.currFries != null) {
            Destroy(cookManagerGameFlow.currFries);
        }

        GameObject newObject = Instantiate(objectToAdd, new Vector3(-0.265f,-0.02f,0.165f), Quaternion.Euler(0f, 45f, 0f));
        newObject.SetActive(true); // spawn object above tray
        cookManagerGameFlow.currFries = newObject;

        // gameFlow.plateValue[gameFlow.idx] = foodValue;
        // gameFlow.idx = gameFlow.idx + 1;
        // Debug.Log("Array Contents: " + string.Join(", ", gameFlow.plateValue));
    }
}
