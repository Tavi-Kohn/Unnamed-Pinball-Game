using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class FlipFlipper : MonoBehaviour
{
    public float ForceUp = 100000;
    public float ForceDown = 10000;

    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Keyboard.current.zKey.isPressed)
        {
            rb.AddTorque(Vector3.down * ForceUp, ForceMode.Force);
        }
        else
        {
            rb.AddTorque(Vector3.up * ForceDown, ForceMode.Force);
        }
    }
}
