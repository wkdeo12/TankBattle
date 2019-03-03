using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Attack : MonoBehaviour
{
    public GameObject Potan;
    public List<GameObject> bulletlist = new List<GameObject>();

    private GameObject MGR;

    private void Start()
    {
        bulletSetting();
        StartCoroutine(ray());
    }

    private void bulletSetting()
    {
        MGR = new GameObject("bulletMGR");
        for (int i = 0; i < 100; i++)
        {
            var go = Instantiate(Potan, transform.position, Quaternion.identity, MGR.transform) as GameObject;
            go.transform.position = transform.position;
            go.SetActive(false);
            bulletlist.Add(go);
        }
    }

    private IEnumerator ray()
    {
        for (; ; )
        {
            if (Physics.Raycast(transform.position, transform.forward, Mathf.Infinity, LayerMask.GetMask("Tank")))
            {
                var go = ShootGo();
                if (go == null) continue;
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;
                go.SetActive(true);
                go.AddComponent<Bullet_Dead>();
            }

            yield return new WaitForSeconds(.2f);
            yield return null;
        }
    }

    private GameObject ShootGo()
    {
        for (int i = 0; i < bulletlist.Count; i++)
        {
            if (!bulletlist[i].activeSelf)
            {
                return bulletlist[i];
            }
        }
        return null;
    }
}