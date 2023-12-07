using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject customerPrefab; // The customer prefab you want to spawn
    public Transform spawnPoint; // The position where customers will spawn
    public float initialDelay = 10.0f; // Initial delay before the first spawn
    public float spawnInterval = 10.0f; // Time interval between customer spawns
    private float nextSpawnTime;
    private int spawnCount = 0; // Counter for the number of spawns
    public int maxSpawns = 2; // Maximum number of spawns

    private void Start()
    {
        // Set the initial spawn time with the initial delay
        nextSpawnTime = Time.time + initialDelay;
    }

    private void Update()
    {
        // Check if it's time to spawn a customer and if the maximum spawns limit hasn't been reached
        if (Time.time >= nextSpawnTime && spawnCount < maxSpawns)
        {
            SpawnCustomer();
            nextSpawnTime = Time.time + spawnInterval; // Set the next spawn time
            spawnCount++; // Increment the spawn counter
        }
    }

    private void SpawnCustomer()
    {
        // Instantiate a new customer at the spawn point with a 180-degree rotation in the X-axis
        GameObject newCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);

        // Rotate the customer prefab 180 degrees in the X-axis
        newCustomer.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
}
