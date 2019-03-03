using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankStatus
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            rb.AddForce(Vector3.forward * 300f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var a = collision.gameObject.GetComponent<Tank>();
            if (a != null)
            {
                Debug.Log(a.hp);
                if (a.hp <= 0) Destroy(collision.gameObject);
            }
        }
    }
}