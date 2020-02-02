using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class GameController : MonoBehaviour
{
    public Canvas P1Win;
    public Canvas P2Win;
    public Canvas P1Lose;
    public Canvas P2Lose;

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

    public int TeamScore0;
    public int TeamScore1;

    // Start is called before the first frame update
    void Start()
    {
        //   for (numberOfPlayers = 2; numberOfPlayers > 0; numberOfPlayers--)
        //   { 
        //   }

        UpdateScore();

        GameObject createdPlayer = Instantiate(Player, Position.position, Quaternion.identity);
        GameObject createdPlayer1 = Instantiate(Player2, Position2.position, Quaternion.identity);

        if (numberOfPlayers == 4) 
        {
            Instantiate(Player3, Position3.position, Quaternion.identity);
            Instantiate(Player4, Position4.position, Quaternion.identity);
        }

        CameraCheck();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Reset();
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        GameObject[] IceBergs = GameObject.FindGameObjectsWithTag("IceBerg");
        TeamScore0 = IceBergs[0].transform.childCount;
        TeamScore1 = IceBergs[1].transform.childCount;

        if (TeamScore0 > 40)
        {
            Time.timeScale = 0;
            P1Win.enabled = true;
            SceneManager.LoadScene("Menu");
        }

        else if (TeamScore1 > 40) 
        {
            Time.timeScale = 0;
            P2Win.enabled = true;
            SceneManager.LoadScene("Menu");

        }

        if (TeamScore0 < 10)
        {
            Time.timeScale = 0;
            P2Lose.enabled = true;
            SceneManager.LoadScene("Menu");

        }
        else if (TeamScore1 < 10)
        {
            Time.timeScale = 0;
            P2Lose.enabled = true;
            SceneManager.LoadScene("Menu");
        }
    }

    void Reset() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void CameraCheck() 
    {
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
}
