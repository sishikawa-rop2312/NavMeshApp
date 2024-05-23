using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * 100f * Time.deltaTime);
        // cc.Move(transform.forward * Input.GetAxis("Vertical") * 5.0f * Time.deltaTime);
        cc.SimpleMove(transform.forward * Input.GetAxis("Vertical") * 1000.0f * Time.deltaTime);
    }
}
