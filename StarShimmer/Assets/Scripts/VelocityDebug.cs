using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityDebug : MonoBehaviour
{
    Rigidbody rb;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z), color);
    }
}
