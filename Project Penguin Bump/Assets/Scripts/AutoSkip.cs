using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSkip : MonoBehaviour
{
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.Deltatime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
