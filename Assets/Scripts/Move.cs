using System.Collections;
using UnityEngine;

public static class Move
{
    /// <summary>
    /// 전진
    /// </summary>
    public static void Advance(this Transform tr, Transform tank, float speed)
    {
        tank.Translate(Vector3.forward * Mathf.Abs(speed) * Time.deltaTime);
    }

    /// <summary>
    /// 각도 회전
    /// </summary>
    public static void AngleRotRight(this Transform tr, Transform tank, float angle)
    {
        Object.FindObjectOfType<TankStatus.Tank>().StartCoroutine(Rotation(tank, angle));
    }

    public static void AngleRotLeft(this Transform tr, Transform tank, float angle)
    {
        angle = -angle;

        Object.FindObjectOfType<TankStatus.Tank>().StartCoroutine(Rotation(tank, angle));
    }

    public static IEnumerator Rotation(Transform tank, float angle)
    {
        for (; ; )
        {
            float ypos = tank.transform.rotation.y;
            tank.transform.rotation = Quaternion.Slerp
                (
                    tank.transform.rotation,
                    Quaternion.Euler
                    (
                        tank.transform.rotation.x,
                        angle,
                        tank.transform.rotation.z
                    ), Time.deltaTime
                );

            //if (angle >= age - 0.05f) break;
            yield return null;
        }
    }
}