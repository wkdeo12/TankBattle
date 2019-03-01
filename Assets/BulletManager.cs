using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(Vector3.forward * 200);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}