using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMovement : MonoBehaviour
{

    public Transform targetObject;
    public float speed = 10f;

    void Update()
    {
        Vector3 relativePosBetweenTwoObjects = (targetObject.position + new Vector3(1, .5f, 0)) - transform.position;
        Quaternion storedRotation = Quaternion.LookRotation(relativePosBetweenTwoObjects);

        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, storedRotation, Time.deltaTime);
        transform.Translate(0, 0, 1 * speed * Time.deltaTime);


    }


}