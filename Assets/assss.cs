using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assss : MonoBehaviour
{
    public GameObject pink; // Reference to the object you want to disable in the new scene
    public GameObject mich;
    public GameObject boy;
    // Start is called before the first frame update
    void Start()
    {
        if (customer_track.character_name == null)
        {
            pink.SetActive(true);
            mich.SetActive(false);
            boy.SetActive(false);
        }
        else if (customer_track.character_name == "mich")
        {
            pink.SetActive(false);
            mich.SetActive(true);
            boy.SetActive(false);
        }

        else if (customer_track.character_name == "boy")
        {
            pink.SetActive(false);
            mich.SetActive(false);
            boy.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
