using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    public GameObject Explosion;
    public float Timer;

    // Start is called before the first frame update
    void Start()
    {
        if (Timer == 0) { Timer = 3; }
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
