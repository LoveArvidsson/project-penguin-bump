using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{

    public Vector3 spawnValues;
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            Respawn(other.gameObject);
            Destroy(other.gameObject); 
        }
    }
    public void Respawn(GameObject playerChar)
    {
        Debug.Log("RESPAWNING");
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
        Instantiate(playerChar, spawnPosition, Quaternion.identity);
        gameController.GetComponent<GameController>().CameraCheck();
    }
}
