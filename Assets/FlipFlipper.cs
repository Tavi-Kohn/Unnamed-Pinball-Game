using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class FlipFlipper : MonoBehaviour
{
    public float force;

    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Keyboard.current.zKey.isPressed)
        {
            rb.AddTorque(Vector3.up * force * Time.fixedDeltaTime, ForceMode.Force);
        }
        else
        {
            rb.AddTorque(Vector3.down * force * Time.fixedDeltaTime, ForceMode.Force);
        }
    }
}
