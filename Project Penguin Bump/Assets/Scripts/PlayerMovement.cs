using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public string HorizontalMove;
    public string VerticalMove;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (speed == 0) { speed = 1; }
        if (force == 0) { force = 100; }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis(HorizontalMove);
        float moveVertical = Input.GetAxis(VerticalMove);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision col) 
    { 
        if (col.gameObject.tag == "Player") 
        {
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
