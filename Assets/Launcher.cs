using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Launcher : MonoBehaviour
{
    private LineRenderer lr;
    public float MaxAngle;
    public float Speed;
    public Transform LaunchPosition;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        var rot = transform.rotation.eulerAngles;
        rot.y = Mathf.Sin(Time.time * Speed) * MaxAngle;
        transform.rotation = Quaternion.Euler(rot);

    }
}
