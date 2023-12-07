using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public OrderGenerator orderGenerator; // Reference to the OrderGenerator script
    public OrderDisplay orderDisplay; // Reference to the OrderDisplay script

    private bool orderGenerated = false; // Flag to track if the order has been generated

    // Method to generate and display an order
    public void GenerateAndDisplayOrder(int numberOfComponents)
    {
        GameObject[] randomOrder = orderGenerator.GenerateRandomOrder(numberOfComponents);
        orderDisplay.UpdateOrderDisplay(randomOrder);
    }

    private void Start()
    {
        int numberOfComponents = 5; // Change this value to the desired number of components for your game
        GenerateAndDisplayOrder(numberOfComponents);
        orderGenerated = true; // Set the flag to indicate order generation
    }

    private void Update()
    {
        // Check if the order has already been generated, if not, don't update
        if (!orderGenerated)
            return;

        // Your other update logic goes here...
    }
}
