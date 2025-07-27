using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class IngredientPhysics : MonoBehaviour
{
    public GameController controller;

    private void Start()
    {
        controller = FindAnyObjectByType<GameController>(); 
    }



    private void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (transform.position.z - Camera.main.transform.position.z)));
        point.z = transform.position.z;
        transform.position = point;

    }

    private void OnMouseUpAsButton()
    {
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((this.transform.position.x < -3.5 || this.transform.position.x > 3.5) && controller.findObject(this.gameObject))
        {
            controller.removeObject(this.gameObject);
        }
        else if ((this.transform.position.x > -3.5 && this.transform.position.x < 3.5) && controller.findObject(this.gameObject) == false)
        {
            controller.addNewObject(this.gameObject);

        }
    }
}
