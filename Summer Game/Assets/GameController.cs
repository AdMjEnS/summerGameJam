using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject Circle;
    public GameObject Square;
    public GameObject[] phantomObjects;
    public GameObject[] newObjects;

    public void spawnObjects()
    {
        int randAmount = Random.Range(1, 10);
        phantomObjects = new GameObject[10];
        newObjects = new GameObject[10];

        for (int i = 0; i < randAmount; i++)
        {
            int randShape = Random.Range(1, 3);

            if (randShape == 1)
            {
                phantomObjects[i] = Instantiate(Circle, new Vector3(-20, 4 - i, 0), Quaternion.identity);
            }
            else if (randShape == 2)
            {
                phantomObjects[i] = Instantiate(Square, new Vector3(-20, 4 - i, 0), Quaternion.identity);
            }
        }
    }

    public void addNewObject(GameObject newObject)
    {
        if (newObjects[0] == null)
        {
            newObjects[0] = newObject;
            return;
        }

        for(int i = 0; i < newObjects.Length; i++)
        {
            if (newObjects[i + 1] == null)
            {
                newObjects[i + 1] = newObject;
                return; 
            }
        }
    }

    public void removeObject(GameObject newObject)
    {
        if (newObjects[0] == null)
        {
            newObjects[0] = newObject;
            return;
        }

        GameObject[] tempList = new GameObject[10];
        int temp = 0;

        for (int i = 0; i < newObjects.Length; i++)
        { 
            if (newObjects[i] == newObject)
            {
                i++;
            }
            tempList[temp] = newObjects[i];
            temp++;
        }

        newObjects = tempList;
    }

    public bool findObject(GameObject newObject)
    {
        if (newObjects[0] == null)
        {
            return false;
        }

        for (int i = 0; i < newObjects.Length; i++)
        {
            if (newObjects[i] == newObject)
            {
                return true;
            }
        }

        return false;

    }

}
