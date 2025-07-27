using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public AccuracyCheck checker;
    public GameObject item;
    public GameController controller;
    public string Name;
    private void OnMouseDown()
    {
        switch(Name)
        {
            case "Reset" :
                checker.Clear();
                break;
            case "Check":
                checker.Check(); 
                break;
            case "Spawn":
                Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);
                break;

        }
    }
}
