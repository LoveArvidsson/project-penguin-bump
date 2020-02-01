﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public string HorizontalMove;
    public string VerticalMove;
    public float force;

    public float maxSpeedX;
    public float maxSpeedZ;

    private float ignoreMaxSpeed;

    public GameObject Bomb;

    // Start is called before the first frame update
    void Start()
    {
        ignoreMaxSpeed = 0;
        rb = GetComponent<Rigidbody>();
        if (speed == 0) { speed = 1; }
        if (force == 0) { force = 150; }
        if (maxSpeedX == 0) { maxSpeedX = 5; }
        if (maxSpeedZ == 0) { maxSpeedZ = 5; }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bomb, gameObject.transform);
        }

        float moveHorizontal = Input.GetAxis(HorizontalMove);
        float moveVertical = Input.GetAxis(VerticalMove);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movement * speed);
        
        if (ignoreMaxSpeed <= 0)
        {
            if (rb.velocity.x >= maxSpeedX) { rb.velocity = new Vector3(maxSpeedX, rb.velocity.y, rb.velocity.z); }
            if (rb.velocity.z >= maxSpeedZ) { rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxSpeedZ); }
            if (rb.velocity.x <= -maxSpeedX) { rb.velocity = new Vector3(-maxSpeedX, rb.velocity.y, rb.velocity.z); }
            if (rb.velocity.z <= -maxSpeedZ) { rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxSpeedZ); }
        }
        else
        {
            ignoreMaxSpeed -= Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision col) 
    { 
        if (col.gameObject.tag == "Player") 
        {
            ignoreMaxSpeed = 3;

            Debug.Log("COLLIDING");
            // Calculate Angle Between the collision point and the player
            Vector3 dir = col.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * force);

            //rb.velocity = col.gameObject.GetComponent<Rigidbody>().velocity;
            //rb.AddForce(Vector3 * -speed);
        }
    }
}
