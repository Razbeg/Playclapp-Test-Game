using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerPool
{
    private List<GameObject> gameObjects = null;
    private GameObject spawnObject = null;


    public SpawnerPool(GameObject spawnObject)
    {
        gameObjects = new List<GameObject>();
        this.spawnObject = spawnObject;
        GameObject gameObject = null;

        for (var i = 0; i < 5; i++)
        {
            gameObject = Object.Instantiate(spawnObject, Spawner.Transform);
            AddToPool(gameObject);
        }
    }


    public void AddToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObjects.Add(gameObject);
    }

    public GameObject GetObject()
    {
        var gameObject = gameObjects.FirstOrDefault(obj => !obj.activeInHierarchy);

        if (gameObject == null)
        {
            gameObject = Object.Instantiate(spawnObject, Spawner.Transform);
            AddToPool(gameObject);
        }

        gameObject.SetActive(true);
        return gameObject;
    }
}
