using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    CharacterController cc;
    float pushPower = 2.0f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * 100f * Time.deltaTime);
        cc.Move(transform.forward * Input.GetAxis("Vertical") * 5.0f * Time.deltaTime);
        // cc.SimpleMove(transform.forward * Input.GetAxis("Vertical") * 1000.0f * Time.deltaTime); // SimpleMoveはジャンプできないし、力加減をMoveより強くする必要がある
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb == null || rb.isKinematic)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        rb.velocity = pushDir * pushPower;
    }
}
