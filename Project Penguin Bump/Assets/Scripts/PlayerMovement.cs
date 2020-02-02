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

    public float firePower;
    public float fireSpeed;

    public float maxSpeedX;
    public float maxSpeedZ;

    private float ignoreMaxSpeed;

    public GameObject Bomb;
    public Transform bombPosition;

    private float nextFire;
    private bool readyToFire;
    private float baseFirePower;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (speed == 0) { speed = 1; }
        nextFire = 0;
        readyToFire = false;
        baseFirePower = firePower;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && nextFire <= 0)
        {
            readyToFire = true;
            if (firePower <= 20)
            {
                firePower += Time.deltaTime * 10;
            }
        }

        if (Input.GetButtonUp("Fire1") && readyToFire == true) 
        {
            GameObject bombSpawn = Instantiate(Bomb, bombPosition.transform.position, bombPosition.transform.rotation);
            bombSpawn.GetComponent<Rigidbody>().velocity = bombPosition.transform.forward * firePower;
            nextFire = fireSpeed;
            firePower = baseFirePower;
            readyToFire = false;
        }

        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }
        

        float moveHorizontal = Input.GetAxis(HorizontalMove);
        float moveVertical = Input.GetAxis(VerticalMove);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);

        rb.AddForce(movement * speed);
    }
}
