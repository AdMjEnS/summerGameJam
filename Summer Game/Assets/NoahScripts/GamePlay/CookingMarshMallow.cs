using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMarshMallow : MonoBehaviour
{
    public float cookTimer = 6.0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            cookTimer -= Time.deltaTime;

            if (cookTimer <= 3 && cookTimer >= 0)
            {
                tag = "CookedMallow";
                GetComponentInChildren<SpriteRenderer>().color = new Color(125, 74, 0, 1);
            }
            else if (cookTimer <= 0)
            {
                tag = "BurntMallow";
                GetComponentInChildren<SpriteRenderer>().color = Color.black;
            }
        }
    }
}
