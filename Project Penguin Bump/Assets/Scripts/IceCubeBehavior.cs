using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCubeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "IceCube") 
        {
            Debug.Log("CUBES COLLIDING");
            collision.gameObject.AddComponent<HingeJoint>();
            collision.gameObject.GetComponent<HingeJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();

            //collision.gameObject.GetComponent<Transform>().SetParent(this.transform);
            //collision.gameObject.transform.rotation = gameObject.transform.rotation;
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
