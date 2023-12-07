using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class removeButtonHandler : MonoBehaviour
{
    // Reference to the addToStove script
    public addToStove addToStoveScript;
    // Stove index associated with this button
    public int stoveIndex;

    void Start()
    {
        // Assuming the button click event is handled by the Button component
        Button button = GetComponent<Button>();
        
        // Attach the callback to the button click event
        button.onClick.AddListener(OnRemoveButtonClick);
    }

    // Called when the button is clicked
    public void OnRemoveButtonClick()
    {
        // Call the removePatty method in addToStove script with the corresponding stove index
        addToStoveScript.removePatty(stoveIndex);
    }
}
