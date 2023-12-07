using UnityEngine;

public class CustomerInteraction : MonoBehaviour
{
    public NewBehaviourScript newBehaviourScript; // Reference to the NewBehaviourScript

    private void Update()
    {
        // Check if the player clicked the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the mouse cursor on screen in the direction of the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the ray hit this customer
                if (hit.transform == transform)
                {
                    // The player clicked on this customer
                    Debug.Log("Clicked on customer!");

                    // Generate and display a new order
                    newBehaviourScript.GenerateAndDisplayOrder(5); 
                }
            }
        }
    }
}
