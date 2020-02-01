using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public Transform Position;
    public GameObject Player2;
    public Transform Position2;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, Position.position, Quaternion.identity);
        Instantiate(Player2, Position2.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Reset();
        }
    }

    void Reset() 
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
