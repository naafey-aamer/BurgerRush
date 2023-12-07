using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cookManagerGameFlow : MonoBehaviour
{
    
    public static int cookedPatties = 0;
    public static GameObject[] stoves = new GameObject[4];
    public static bool[] canRemove = new bool[4];

    public TMP_Text[] publicText = new TMP_Text[4];
    public static float[] timer = new float[4];
    public static bool[] isTiming = new bool[4];

    public static GameObject currDrink = null;
    public static GameObject currFries = null;
    public static GameObject currDip = null;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            stoves[i] = null; // initialise all stoves to be null
            canRemove[i] = false; 

            timer[i] = 0f;
            isTiming[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
