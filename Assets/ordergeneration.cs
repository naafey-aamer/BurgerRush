using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour
{

    // public GameObject[] menuItems; // Assign the placeholder blocks in the Unity Inspector

    public int[] GenerateRandomOrder(int numberOfComponents)
    {
        int[] order = new int[numberOfComponents];

        // Assigning static values
        order[0] = SampleOrderManager.orderValue[0];
        order[9] = SampleOrderManager.orderValue[9];

        // Assigning random values within specified ranges
        for (int i = 1; i <= 8; i++)
        {
            order[i] = Random.Range(2, 10);
        }

        order[10] = Random.Range(-4, 0); // Values between -4 and -1
        order[11] = (Random.Range(0, 2) == 0) ? -11 : -12; // Either -11 or -12
        order[12] = Random.Range(-10, -6); // Values between -10 and -7

        return order;
    }
}