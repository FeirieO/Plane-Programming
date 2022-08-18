using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpin : MonoBehaviour
{
    public float speed = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.fixedDeltaTime, Space.Self);
    }
}
