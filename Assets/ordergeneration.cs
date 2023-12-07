using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 2d array public static array. len will be the max number of customers for that level
// reset array to zero whenen new level starts
// size 14
// order_value
// 

public class OrderGenerator : MonoBehaviour
{
    public GameObject[] menuItems; // Assign the placeholder blocks in the Unity Inspector

    public GameObject[] GenerateRandomOrder(int numberOfComponents)
    {
        GameObject[] order = new GameObject[numberOfComponents];

        for (int i = 0; i < numberOfComponents; i++)
        {
            int randomIndex = Random.Range(0, menuItems.Length);
            order[i] = menuItems[randomIndex];
        }

        return order;
    }
}
