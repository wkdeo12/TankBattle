using UnityEngine;

public class Test : MonoBehaviour
{
    private Transform tr;

    // Start is called before the first frame update
    private void Start()
    {
        //Transform.GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        tr.Advance(transform, 4);
        tr.AngleRotLeft(transform, 60.0f);
    }
}