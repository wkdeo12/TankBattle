using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD
{
    public class TankAI : MonoBehaviour
    {
        private float speed = 0;
        private Rigidbody rb;
        private Transform target;
        private Transform launcher;
        private GodTankStateMachine stateMachine;
        private new BoxCollider collider;
        public GameObject bullet;

        private void Awake()
        {
            speed = GetComponent<TankStatus.Tank>().speed;
            rb = GetComponent<Rigidbody>();
            launcher = transform.GetChild(0).GetChild(0);
            stateMachine = GetComponent<GodTankStateMachine>();
            collider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            List<Collider> a = new List<Collider>(Physics.OverlapSphere(this.transform.position, 30f));

            foreach (var item in a)
            {
                if (item.GetComponent<TankStatus.Tank>() != null)
                {
                    target = item.GetComponent<TankStatus.Tank>().transform;
                    if (target.transform.position != this.transform.position)
                    {
                        break;
                    }
                }
            }

            Destroy(target.GetChild(0).gameObject);
            StartCoroutine(Hitable());
            StartCoroutine(Targeting());
            StartCoroutine(Guard());
        }

        private IEnumerator Targeting()
        {
            while (true)
            {
                if (launcher != null)
                {
                    launcher.LookAt(target);
                    Instantiate(bullet, launcher.position, Quaternion.identity);
                }
                else launcher = transform.GetChild(0).GetChild(0);
                yield return null;
            }
        }

        private IEnumerator Guard()
        {
            while (true)
            {
                rb.useGravity = false;
                collider.enabled = false;
                yield return null;
            }
        }

        private IEnumerator Hitable()
        {
            while (true)
            {
                if (target == null)
                {
                    yield break;
                }
                var col = target.GetComponent<BoxCollider>();
                if (col.enabled == false)
                {
                    col.enabled = true;
                }
                yield return null;
            }
        }
    }
}