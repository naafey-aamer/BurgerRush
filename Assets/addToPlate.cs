using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addToPlate : MonoBehaviour
{
    // audio 
    public AudioSource audioSource;

    public GameObject objectToAdd;
    public int foodValue;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {   
        if (objectToAdd == GameObject.Find("Patty")) {
            if (cookManagerGameFlow.cookedPatties <= 0) { // no more cooked patties available
                Debug.Log("No more cooked patties: cook more patties");
                return;
            }
            else { // decrement cooked patties
                cookManagerGameFlow.cookedPatties = cookManagerGameFlow.cookedPatties - 1;
                Debug.Log("cooked patties decremented, new value: " + cookManagerGameFlow.cookedPatties);
            }
        }

        GameObject newObject = Instantiate(objectToAdd, new Vector3(0f,0.3f,0f), Quaternion.identity);
        newObject.SetActive(true); // spawn object above plate 

        gameFlow.plateValue[gameFlow.idx] = foodValue;
        gameFlow.idx = gameFlow.idx + 1;
        Debug.Log("Array Contents: " + string.Join(", ", gameFlow.plateValue));

        // play sound
        audioSource.Play();
    }

}
