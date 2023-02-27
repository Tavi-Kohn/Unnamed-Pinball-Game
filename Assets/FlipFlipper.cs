using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class FlipFlipper : MonoBehaviour
{
    public float ForceOn = 5000;
    public float ForceReset = 1000;
    public float LockDelay = 0.5f;

    private Rigidbody rb;
    private float freezeTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var z = Keyboard.current.zKey;
        if (z.wasPressedThisFrame || z.wasReleasedThisFrame)
        {
            freezeTimer = 0;
            rb.isKinematic = false;
        }
    }

    void FixedUpdate()
    {
        if (freezeTimer >= LockDelay)
        {
            rb.isKinematic = true;
        }

        if (Keyboard.current.zKey.isPressed)
        {
            rb.AddTorque(Vector3.down * ForceOn, ForceMode.Force);
        }
        else
        {
            rb.AddTorque(Vector3.up * ForceReset, ForceMode.Force);
        }

        freezeTimer += Time.fixedDeltaTime;
    }
}
