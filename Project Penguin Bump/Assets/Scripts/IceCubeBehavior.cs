using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeBehavior : MonoBehaviour
{
    public float graceTimer;
    public List<HingeJoint> hingeJoints = new List<HingeJoint>();
    public float maxSpeed;
    public float timerTime;

    // Start is called before the first frame update
    void Start()
    {
        if (graceTimer == 0) { graceTimer = 2;  }
        if (maxSpeed == 0) { maxSpeed = 2.0f; }
        timerTime = graceTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerTime < graceTimer)
        {
            timerTime += Time.deltaTime;
        }
        else if (timerTime > graceTimer) { timerTime = graceTimer;  }
    }

    void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.x > maxSpeed) { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(maxSpeed, 0, 0); }
        if (gameObject.GetComponent<Rigidbody>().velocity.x < -maxSpeed) { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-maxSpeed, 0, 0); }
        if (gameObject.GetComponent<Rigidbody>().velocity.z > maxSpeed) { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, maxSpeed); }
        if (gameObject.GetComponent<Rigidbody>().velocity.z < -maxSpeed) { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -maxSpeed); }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "IceCube") 
        {
            if (timerTime >= graceTimer && collision.gameObject.GetComponent<IceCubeBehavior>().timerTime >= graceTimer) 
            { 
                Debug.Log("CUBES COLLIDING");

                hingeJoints.Add(gameObject.AddComponent<HingeJoint>());
                gameObject.GetComponent<HingeJoint>().connectedBody = collision.gameObject.GetComponent<Rigidbody>();
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }

            //collision.gameObject.GetComponent<Transform>().SetParent(this.transform);
            //collision.gameObject.transform.rotation = gameObject.transform.rotation;
        }

        if (collision.gameObject.tag == "Boundry") 
        {
            Vector3 dir = transform.position - collision.transform.position;
            dir.Normalize();
            gameObject.GetComponent<Rigidbody>().velocity = dir * 15;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "IceCube")
        {
            Debug.Log("CUBES NOT COLLIDING");
         //   collision.gameObject.GetComponent<Transform>().SetParent(null);
        }
    }
}
