using UnityEngine;
using UnityEngine.UI;

public class OrderDisplay : MonoBehaviour
{
    public Text orderDisplayText; // Reference to the UI Text element
    // public GameObject[] menuItems; // Reference to the menu items

    public static OrderDisplay Instance { get; private set; }
    private GameObject[] savedOrder;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(orderDisplayText);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateOrderDisplay()
    {
        // Concatenating array elements into a single string
        string arrayString = string.Join(", ", SampleOrderManager.orderValue);

        // Printing the concatenated string to the console log
        Debug.Log("Array elements: " + arrayString);
        // Clear the existing text
        orderDisplayText.text = "";
        // Create a table header
        orderDisplayText.text += "Order:\n";
        orderDisplayText.text += "--------------------------------\n";

        // Display items according to the new orderValue array
        for (int i = 0; i < SampleOrderManager.orderValue.Length; i++)
        {
            if (i == 0 || i == 9)
            {
                // Static indexes display bacon, pickle, cheese, etc.
                string itemName = GetItemNameForStaticIndex(i);
                orderDisplayText.text += string.Format("| {0, -30} |\n", itemName);
            }
            else if (i >= 1 && i <= 8)
            {
                // Display random items from bacon, pickle, cheese, etc.
                string randomItemName = GetRandomItemName(SampleOrderManager.orderValue[i]);
                orderDisplayText.text += string.Format("| {0, -30} |\n", randomItemName);
            }
            else if (i == 10)
            {
                // Displaying soda names based on values at index 10
                string sodaName = GetSodaName(SampleOrderManager.orderValue[i]);
                orderDisplayText.text += string.Format("| {0, -30} |\n", sodaName);
            }
            else if (i == 11)
            {
                // Displaying fries names based on values at index 11
                string friesName = GetFriesName(SampleOrderManager.orderValue[i]);
                orderDisplayText.text += string.Format("| {0, -30} |\n", friesName);
            }
            else if (i == 12)
            {
                // Displaying dip names based on values at index 12
                string dipName = GetDipName(SampleOrderManager.orderValue[i]);
                orderDisplayText.text += string.Format("| {0, -30} |\n", dipName);
            }
        }

        // Add a bottom line to the table
        orderDisplayText.text += "--------------------------------";
    }

    private string GetItemNameForStaticIndex(int index)
    {
        // Static items' names for specific indexes
        string[] staticItems = { "Bottom Bun", "", "", "", "", "", "", "", "", "Top Bun" };
        return staticItems[index];
    }

    private string GetRandomItemName(int value)
    {
        // Random items' names based on values at indexes 1-8
        string[] randomItems = { "bacon", "pickle", "cheese", "onion", "lettuce", "patty", "ketchup", "mayo" };
        return randomItems[value - 2]; // Adjust index for item name
    }

    private string GetSodaName(int value)
    {
        // Names for soda based on values at index 10
        string[] sodaNames = { "", "pepsi", "fanta", "7up", "coke" };
        int sodaIndex = -value; // Invert value for the index
        return sodaNames[sodaIndex];
    }

private string GetFriesName(int value)
{
    // Names for fries based on values at index 11
    string[] friesNames = { "", "", "large fries", "small fries" };

    int friesIndex = Mathf.Abs(value) - 9;
    Debug.Log(friesIndex);
    if (friesIndex >= 0 && friesIndex < friesNames.Length)
    {
        return friesNames[friesIndex];
    }
    else
    {
        return "Invalid Fries"; // Handle the out-of-bounds condition
    }
}





    private string GetDipName(int value)
    {
        // Names for dips based on values at index 12
        string[] dipNames = { "", "", "", "", "ketchup", "bbq", "mayo", "mustard" };
        int dipIndex = -value - 6; // Adjust index according to value range
        return dipNames[dipIndex];
    }

    // Method to retrieve the saved order
    public GameObject[] GetSavedOrder()
    {
        return savedOrder;
    }
}
