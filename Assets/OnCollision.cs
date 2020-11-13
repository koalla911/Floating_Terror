using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Vector3 collPosition = coll.transform.position;

        if (collPosition.y > transform.position.y)
        {
            Debug.Log("its above");
        }
        else
        {
            Debug.Log("its below");
        }

        if (collPosition.x > transform.position.x)
        {
            Debug.Log("its right");
        }
        else
        {
            Debug.Log("its left");
        }


    }
}
