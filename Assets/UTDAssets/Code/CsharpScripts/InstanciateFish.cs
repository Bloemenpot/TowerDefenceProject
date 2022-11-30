using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateFish : MonoBehaviour
{
    public GameObject fishToSpawn;
    Vector3 fishSpawnLocation = new Vector3(0,0,0);
    Vector2 randomSeed;

    void Update()
    {
        if (Input.GetButtonDown("SpawnFish"))
        {
            GameObject spawn;
            randomSeed = new Vector2(Random.Range(0, 65536), Random.Range(0, 65536));
            spawn = Instantiate(fishToSpawn, fishSpawnLocation, Quaternion.identity) as GameObject;
            spawn.GetComponent<Renderer>().material.SetVector("_seed", randomSeed);
            fishSpawnLocation += new Vector3(5, 0, 0);
        }
    }
}
