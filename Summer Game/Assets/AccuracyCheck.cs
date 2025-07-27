using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyCheck : MonoBehaviour
{
    public GameController controller;
    private bool isAccurate = false;
    public GameObject winObj;

    private int circleCnt;
    private int squareCnt;
    // Start is called before the first frame update
    void Start()
    {
        controller.spawnObjects();

        for (int i = 0; i < controller.phantomObjects.Length; i++)
        {
            if (controller.phantomObjects[i] != null && controller.phantomObjects[i].tag == "CircleObj")
            {
                circleCnt++;
            }
            else if (controller.phantomObjects[i] != null && controller.phantomObjects[i].tag == "SquareObj")
            {
                squareCnt++;
            }
        }
    }

    // Update is called once per frame
    public void Check()
    {
        int newCircleCnt = 0;
        int newSquareCnt = 0;

        if (controller.newObjects[0] != null)
        {
            for (int i = 0; i < controller.newObjects.Length; i++)
            {
                if (controller.newObjects[i] != null && controller.newObjects[i].tag == "CircleObj")
                {
                    newCircleCnt++;
                }
                else if (controller.newObjects[i] != null && controller.newObjects[i].tag == "SquareObj")
                {
                    newSquareCnt++;
                }
            }


            if (newCircleCnt == circleCnt && newSquareCnt == squareCnt)
            {
                isAccurate = true;
            }
            else
            {
                isAccurate = false;
            }

            if (isAccurate)
            {
                winObj.SetActive(true);
            }
            else
            {
                winObj.SetActive(false);
            }

        }
        else
        {
            winObj.SetActive(false);
        }
    }

    public void Clear()
    {
        for (int i = 0; i < controller.newObjects.Length; i++)
        {
            Destroy(controller.newObjects[i]);
        }
    }
}
