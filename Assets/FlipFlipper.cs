using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class FlipFlipper : MonoBehaviour
{
    public float ForceUp = 10000;
    public float ForceDown = 1000;

    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Keyboard.current.zKey.isPressed)
        {
            rb.AddTorque(Vector3.down * ForceUp * Time.fixedDeltaTime, ForceMode.Force);
        }
        else
        {
            rb.AddTorque(Vector3.up * ForceDown * Time.fixedDeltaTime, ForceMode.Force);
        }
    }
}
