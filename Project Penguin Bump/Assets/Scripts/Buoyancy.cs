using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public float waterLevel, floatHeight;
    public Vector3 buoyancyCentreOffset;
    public float bounceDamp;

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
        float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);

        if (forceFactor > 0f)
        {
            Vector3 uplift = -Physics.gravity * (forceFactor - rigidbody.velocity.y * bounceDamp);
            rigidbody.AddForceAtPosition(uplift, actionPoint);
        }
    }
}
