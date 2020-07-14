using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region Variables
    // The game object we want to pool
    [SerializeField] GameObject prefab;

    // The number of game objects we want to pool
    [SerializeField] int maxPooledObjects = 10;

    // A queue to store the pooled objects in
    Queue<GameObject> pooledObjects = new Queue<GameObject>();

    // Static instance of the object pool so the after image effect can get it
    public static ObjectPool Instance { get; private set; }
    #endregion

    #region Unity Base Methods
    void Awake()
    {
        // Set the static instance
        Instance = this;

        // Create the object pool
        CreatePool();
    }
    #endregion

    #region User Methods
    void CreatePool()
    {
        // Loop through & instantiate the pooled objects
        for (int i = 0; i < maxPooledObjects; i++)
        {
            // Create the object
            GameObject pooledItem = Instantiate(prefab);

            // Set it's position
            pooledItem.transform.SetParent(transform);

            // Add to object pool
            AddToPool(pooledItem);
        }
    }

    public void AddToPool(GameObject gameObject)
    {
        // Set the game object to be inactive
        gameObject.SetActive(false);

        // Add it to the queue
        pooledObjects.Enqueue(gameObject);
    }

    public GameObject GetFromPool()
    {
        // Check if we have enough pooled objects, if not create some more
        if (pooledObjects.Count == 0)
            CreatePool();

        // Get the pooled object
        GameObject pooledItem = pooledObjects.Dequeue();

        // Set the game object to be active
        pooledItem.SetActive(true);

        // Return the pooled object
        return pooledItem;
    }
    #endregion
}