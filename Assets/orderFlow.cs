using UnityEngine;

public class SampleOrderManager : MonoBehaviour
{
    public static int[] orderValue = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 10, 0, 0, 0};
    
    private void Start()
    {
        // Generate a random order
        OrderGenerator a = new OrderGenerator();
        int[] randomOrder = a.GenerateRandomOrder(13);

        // Assign the generated order to the static orderValue in OrderDisplay
        orderValue = randomOrder;

        // Access the OrderDisplay instance and update the order display
        OrderDisplay o = OrderDisplay.Instance;
        if (o != null)
        {
            o.UpdateOrderDisplay();
        }
        else
        {
            Debug.LogError("OrderDisplay Instance not found!");
        }
    }
}
