using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public string HorizontalMove;
    public string VerticalMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (speed == 0) { speed = 1; }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis(HorizontalMove);
        float moveVertical = Input.GetAxis(VerticalMove);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
}
