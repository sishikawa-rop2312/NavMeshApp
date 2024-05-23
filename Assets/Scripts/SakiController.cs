using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakiController : MonoBehaviour
{
    public CharMove charMove;

    void OnTriggerEnter(Collider other)
    {
        if (charMove.isAttacking)
        {
            Destroy(other.gameObject);
        }
    }
}
