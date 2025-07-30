using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredients : MonoBehaviour
{
    public GameObject Spawner;
    public GameObject[] Ingredients;

    public float randomNumber;

    public void SpawnChocolate()
    {
        Instantiate(Ingredients[0], new Vector3(Spawner.transform.position.x + Random.Range(-6, 6), Spawner.transform.position.y), Spawner.transform.rotation);
    }

    public void SpawnMarshmellow()
    {
        Instantiate(Ingredients[1], new Vector3(Spawner.transform.position.x + Random.Range(-6, 6), Spawner.transform.position.y), Spawner.transform.rotation);
    }

    public void SpawnCracker()
    {
        Instantiate(Ingredients[2], new Vector3(Spawner.transform.position.x + Random.Range(-6, 6), Spawner.transform.position.y), Spawner.transform.rotation);
    }
}
