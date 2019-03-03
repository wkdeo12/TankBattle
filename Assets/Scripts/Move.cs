using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float angle;

    public float Angle
    {
        get => angle;
        set => angle = Mathf.Abs(value);
    }

    private float speed;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Abs(value);
    }

    /// <summary>
    /// 전진
    /// </summary>
    public void Advance(float speed)
    {
        transform.Translate(Vector3.forward * Mathf.Abs(speed) * Time.deltaTime);
    }

    /// <summary>
    /// 각도 회전
    /// </summary>
    public void AngleRotRight(float angle)
    {
        StartCoroutine(Rotation(angle));
    }

    public void AngleRotLeft(float angle)
    {
        angle = -angle;
        StartCoroutine(Rotation(angle));
    }

    public IEnumerator Rotation(float angle)
    {
        float age;
        for (; ; )
        {
            age = Mathf.Lerp(0, angle, Time.deltaTime);

            yield return null;
        }
    }
}