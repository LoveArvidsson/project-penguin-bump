using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;


public class GameController : MonoBehaviour
{
    public GameObject Player;
    public Transform Position;
    public GameObject Player2;
    public Transform Position2;
    CinemachineTargetGroup targetGroup;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, Position.position, Quaternion.identity);
        Instantiate(Player2, Position2.position, Quaternion.identity);

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
