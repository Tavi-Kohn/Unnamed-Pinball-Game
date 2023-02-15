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
    public float launchForce;
    private float timer;
    public float cooldown;
    public Transform LaunchPosition;
    private Rigidbody capturedB;


    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        sc = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        var rot = transform.rotation.eulerAngles;
        rot.y = Mathf.Sin(Time.time * Speed) * MaxAngle;
        transform.rotation = Quaternion.Euler(rot);
        
        if(Keyboard.current.zKey.wasPressedThisFrame && capturedB != null)
        {
            sc.enabled = false;
            capturedB.isKinematic = false;
            
            capturedB.AddForce(transform.forward*launchForce);
            capturedB = null;
            
        }

    }

    private void FixedUpdate()
    {

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {

            collider.gameObject.transform.position = LaunchPosition.position;
            collider.attachedRigidbody.isKinematic = true;
            capturedB = collider.attachedRigidbody;
        }


    }
    private void cooldown]
}




