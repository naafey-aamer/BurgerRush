using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer_track : MonoBehaviour
{
    public GameObject pink; // Reference to the object you want to disable in the new scene
    public GameObject mich;
    public GameObject boy;
    public static string character_name = null;
    // Start is called before the first frame update
    void Start()
    {
        pink.SetActive(true);
        mich.SetActive(false);
        boy.SetActive(false);
        
        if (character_name == "mich")
        {
            pink.SetActive(false);
            mich.SetActive(true);
            boy.SetActive(false);
        }

        else if (character_name == "boy")
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
