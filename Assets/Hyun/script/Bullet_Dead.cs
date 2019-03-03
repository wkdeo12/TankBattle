using System.Collections;
using UnityEngine;

public class Bullet_Dead : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform pos;

    private void Start()
    {
        StartCoroutine(bulletPull());
        pos = FindObjectOfType<Tank_Attack>().transform;
    }

    private IEnumerator bulletPull()
    {
        for (; ; )
        {
            if (transform.position.z >= 30.0f)
            {
                Bullet_Reset();
            }
            yield return null;
        }
    }

    private void Bullet_Reset()
    {
        var go = GetComponent<Bullet_Dead>();
        go.gameObject.SetActive(false);

        Destroy(go);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullet_Reset();
    }
}