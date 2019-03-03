using System;
using System.Collections;
using UnityEngine;

public class Tank_Move : MonoBehaviour
{
    // Start is called before the first frame update

    private float angle = 0f;
    private float range = 1000.0f;

    public struct MathPos
    {
        public float x;
        public float z;
    }

    private MathPos pos = new MathPos();

    private Vector3 mathPos = Vector3.zero;

    private Action tackMove = () => { };

    private void Start()
    {
        //tackMove += Advance;
        //tackMove += Turn;
        tackMove += Statik;
        StartCoroutine(TankRunning());
    }

    private IEnumerator TankRunning()
    {
        for (; ; )
        {
            //angle += Time.deltaTime * 3;
            tackMove?.Invoke();
            yield return new WaitForSeconds(0.02f);
            yield return null;
        }
    }

    private void Advance()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5.0f);
    }

    private void Turn()
    {
        var go = FindEnemy();
        var DirNDis = dirNdis(go);

        DirNDis.dir.y = 0;
        Quaternion look = Quaternion.LookRotation(DirNDis.dir);
        transform.rotation = look;
    }

    /// <summary>
    /// 타겟을 중심으로 공전
    ///
    /// </summary>
    public void Statik()
    {
        var enemy = FindEnemy();

        var DirNDis = dirNdis(enemy);

        mathPos.x = Mathf.Cos(angle) * DirNDis.distance;
        mathPos.z = Mathf.Sin(angle) * DirNDis.distance;

        DirNDis.dir.y = 0;
        Quaternion look = Quaternion.LookRotation(DirNDis.dir);
        transform.rotation = look;

        transform.position = mathPos + enemy.transform.position;
    }

    private (Vector3 dir, float distance) dirNdis(GameObject enemy)
    {
        var dir = (enemy.transform.position - transform.position);

        float distance = dir.magnitude;
        return (dir, distance);
    }

    private GameObject FindEnemy()
    {
        var goList = FindRangeTank();

        GameObject enemy = null;
        if (goList.Length >= 2)
        {
            enemy = goList[0].gameObject;
        }

        return enemy;
    }

    private Collider[] FindRangeTank()
    {
        var gos = Physics.OverlapSphere(transform.position, range, LayerMask.GetMask("Tank"));

        return gos;
    }
}