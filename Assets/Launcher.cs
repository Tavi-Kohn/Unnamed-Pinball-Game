using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(SphereCollider))]
public class Launcher : MonoBehaviour
{
    private LineRenderer lr;
    private SphereCollider sc;
    public float MaxAngle;
    public float Speed;
    public float LaunchForce;
    // private float lastLaunchTime;
    public float Cooldown;
    public Transform LaunchPosition;
    private Rigidbody capturedB;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        // lastLaunchTime = Time.time - Cooldown;
        lr = GetComponent<LineRenderer>();
        sc = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        var rot = transform.rotation.eulerAngles;
        rot.y = Mathf.Sin(Time.time * Speed) * MaxAngle;
        transform.rotation = Quaternion.Euler(rot);

        if (Keyboard.current.zKey.wasPressedThisFrame && capturedB != null)
        {
            timer = 0f;
            sc.enabled = false;

            capturedB.isKinematic = false;
            capturedB.AddForce(transform.forward * LaunchForce);
            capturedB = null;
        }
        timer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timer > Cooldown)
        {
            sc.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        // if (collider.gameObject.tag == "Player" && Time.fixedTime - lastLaunchTime >= Cooldown)
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.transform.position = LaunchPosition.position;
            collider.attachedRigidbody.isKinematic = true;
            capturedB = collider.attachedRigidbody;
        }
    }
}




