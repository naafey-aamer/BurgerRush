using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonActivatorWin : MonoBehaviour
{
    public Button myButton;

    void Start()
    {
        // Assuming some condition (replace this with your condition)
        bool conditionMet = CheckCondition(); // Your condition check here

        // Set the button active state based on the condition
        myButton.gameObject.SetActive(conditionMet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheckCondition()
    {
        if (gameFlow.numOfCustomers >= 3 && gameFlow.winCondition == true) {
            return true;
        }
        else {
            return false;
        }
    }
}
