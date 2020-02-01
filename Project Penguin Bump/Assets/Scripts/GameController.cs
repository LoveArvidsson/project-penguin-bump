using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class GameController : MonoBehaviour
{
    public int numberOfPlayers;
    public GameObject Player;
    public Transform Position;
    public GameObject Player2;
    public Transform Position2;
    public GameObject Player3;
    public Transform Position3;
    public GameObject Player4;
    public Transform Position4;
    CinemachineTargetGroup targetGroup;

    // Start is called before the first frame update
    void Start()
    {
     //   for (numberOfPlayers = 2; numberOfPlayers > 0; numberOfPlayers--)
     //   { 
     //   }
        GameObject createdPlayer = Instantiate(Player, Position.position, Quaternion.identity);
        GameObject createdPlayer1 = Instantiate(Player2, Position2.position, Quaternion.identity);

        if (numberOfPlayers == 4) 
        {
            Instantiate(Player3, Position3.position, Quaternion.identity);
            Instantiate(Player4, Position4.position, Quaternion.identity);
        }

        //        targetGroup.GetComponent<CinemachineTargetGroup>();
        targetGroup = GameObject.Find("TargetGroup1").GetComponent<CinemachineTargetGroup>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
            Cinemachine.CinemachineTargetGroup.Target target;
            target.target = players[i].transform;
            target.radius = 0;
            target.weight = 1;

            targetGroup.m_Targets.SetValue(target, i);
        }
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
        SceneManager.LoadScene("testscene");
    }
}
