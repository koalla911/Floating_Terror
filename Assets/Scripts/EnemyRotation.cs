using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    void Update() 
    {
        //targetTransform = targetTransform.position.x - this.transform.position.x, targetTransform.position.y - this.transform.position.y;
        

        /*float angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler (new Vector3(0, 0, angle - 90));
        Vector3 desiredPosition = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);*/
        float angle = Mathf.Atan2 (targetTransform.position.y, targetTransform.position.x) * Mathf.Rad2Deg;
        Vector3 relativePos = targetTransform.position - transform.position;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle * 2));
        transform.rotation = rotation;
    }
}
