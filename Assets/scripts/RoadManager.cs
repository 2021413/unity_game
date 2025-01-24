using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    //public Transform parent;
    private float size = 18.39f;
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("car")) return;
        //var x = transform.position.x ;
        transform.position = new Vector3(transform.position.x,transform.position.y, transform.position.z + 3* size);
    }
}
