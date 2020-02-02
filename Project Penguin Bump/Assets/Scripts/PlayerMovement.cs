using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public string HorizontalMove;
    public string VerticalMove;
    public string Fire;
    public string Jump;
    public string Honk;
    public float force;

    public float jumpSpeed;

    public float firePower;
    public float fireSpeed;

    public float maxSpeedX;
    public float maxSpeedZ;

    private float ignoreMaxSpeed;

    public GameObject Bomb;
    public Transform bombPosition;

    private float nextFire;
    private bool readyToFire;
    private bool canJump;
    private float baseFirePower;

    public AudioSource honkSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (speed == 0) { speed = 1; }
        nextFire = 0;
        readyToFire = false;
        baseFirePower = firePower;
        if (jumpSpeed == 0) { jumpSpeed = 4; }
        canJump = false;
    }
    // comment
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < 3){ canJump = true; }

        if (Input.GetButtonDown(Honk)) { honkSound.Play(); }

        if (Input.GetButtonDown(Jump) && canJump == true )
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, jumpSpeed, gameObject.GetComponent<Rigidbody>().velocity.z);
            canJump = false;
        }

        if (Input.GetButton(Fire) && nextFire <= 0)
        {
            readyToFire = true;
            if (firePower <= 20)
            {
                firePower += Time.deltaTime * 10;
            }
        }

        if (Input.GetButtonUp(Fire) && readyToFire == true) 
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
        if (movement != null)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
        rb.AddForce(movement * speed);
    }

    void FixedUpdate()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.x > maxSpeedX) { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(maxSpeedX, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z); }
        if (gameObject.GetComponent<Rigidbody>().velocity.x < -maxSpeedX) { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-maxSpeedX, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z); }
        if (gameObject.GetComponent<Rigidbody>().velocity.z > maxSpeedZ) { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, maxSpeedZ); }
        if (gameObject.GetComponent<Rigidbody>().velocity.z < -maxSpeedZ) { gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, -maxSpeedZ); }
    }
}
