using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Player;
    public Transform Position;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, Position.position, Quaternion.identity);
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
