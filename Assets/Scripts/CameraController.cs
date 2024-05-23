using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform hero;
    Vector3 diff;

    void Start()
    {
        diff = transform.position - hero.position;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, hero.position + diff, 0.5f);
    }
}
