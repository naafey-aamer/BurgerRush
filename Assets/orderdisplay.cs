using UnityEngine;
using UnityEngine.UI;

public class OrderDisplay : MonoBehaviour
{
    public Text orderDisplayText; // Reference to the UI Text element
    public GameObject[] menuItems; // Reference to the menu items

    // Singleton instance to store the order
    public static OrderDisplay Instance { get; private set; }
    private GameObject[] savedOrder; // Saved order data

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateOrderDisplay(GameObject[] randomOrder)
    {
        // Clear the existing text
        orderDisplayText.text = "";

        // Create a table header
        orderDisplayText.text += "Order:\n";
        orderDisplayText.text += "--------------------------------\n";

        // Display each object and its name in the table
        foreach (GameObject menuItem in randomOrder)
        {
            orderDisplayText.text += string.Format("| {0, -30} |\n", menuItem.name);
        }

            orderDisplayText.text += string.Format("| {0, -30} |\n", "Patty");

        // Add a bottom line to the table
        orderDisplayText.text += "--------------------------------";

        // Output the order to the console as well
        string orderText = "Order: ";
        foreach (GameObject menuItem in randomOrder)
        {
            orderText += menuItem.name + ", ";
        }
        Debug.Log(orderText);
    }

        // Method to retrieve the saved order
    public GameObject[] GetSavedOrder()
    {
        return savedOrder;
    }

}
