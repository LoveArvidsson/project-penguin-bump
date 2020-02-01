using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Force;

    // Start is called before the first frame update
    void Start()
    {
        if (Force == 0) { Force = 300;  }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Colliding explosion and player");
            Vector3 dir = other.transform.position - transform.position;
            dir.Normalize();
            other.gameObject.GetComponent<Rigidbody>().AddForce(dir);
        }
    }

}
