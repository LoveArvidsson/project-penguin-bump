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
    public CinemachineTargetGroup targetGroup;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, Position.position, Quaternion.identity);
        Instantiate(Player2, Position2.position, Quaternion.identity);

        //        targetGroup.GetComponent<CinemachineTargetGroup>();
        targetGroup = GameObject.Find("TargetGroup1").GetComponent<CinemachineTargetGroup>();
        Cinemachine.CinemachineTargetGroup.Target target;

        target.target = Player.transform;
        target.weight = 1;
        target.radius = 0;

        for (int i = 0; i < targetGroup.m_Targets.Length; i++)
        {
            if (targetGroup.m_Targets[i].target == null)
            {
                targetGroup.m_Targets.SetValue(target, i);
                return;
            }
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
