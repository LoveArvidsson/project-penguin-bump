using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Force;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        if (timer == 0) { timer = 0.3f; }
        if (Force == 0) { Force = 300;  }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Colliding explosion and player");
            Vector3 dir = other.transform.position - transform.position;
            dir.Normalize();
            other.gameObject.GetComponent<Rigidbody>().AddForce(dir * Force);
        }

        if (other.gameObject.tag == "IceCube")
        {
            Destroy(other.gameObject.GetComponent<HingeJoint>());
            Vector3 dir = other.transform.position - transform.position;
            dir.Normalize();
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().AddForce(dir * Force);
        }
    }

}
