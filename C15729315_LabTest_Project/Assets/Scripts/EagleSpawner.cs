using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour 
{
    public float gap = 20;
    public float followers = 2;
    public GameObject prefab;
    LookAtEagle lookAtEagleScript;
    // Use this for initialization
    void Start () 
	{
        // Spawn leader
        lookAtEagleScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LookAtEagle>();
        GameObject leader = Instantiate(prefab, this.gameObject.transform);
        leader.tag = "CameraTarget";
        leader.name = "Leader";
        leader.gameObject.GetComponent<Boid>().isLeader = true;
        lookAtEagleScript.spawned = true;

        // Spawn right-hand followers
        for(int i = 0; i < followers; i++)
        {
            GameObject localPrefab1 = Instantiate(prefab, this.gameObject.transform);

            localPrefab1.tag = "Follower";
            localPrefab1.name = "Follower " + (i + 1);

            if (localPrefab1.tag == "Follower")
            {
                localPrefab1.transform.localPosition = new Vector3((gap * (i + 1)), 0, (-gap * (i + 1)));
            }
        }

        // Spawn left-hand followers
        for (int j = 0; j < followers; j++)
        {
            GameObject localPrefab2 = Instantiate(prefab, this.gameObject.transform);

            localPrefab2.tag = "Follower";
            localPrefab2.name = "Follower " + (j + 3);

            if (localPrefab2.tag == "Follower")
            {
                localPrefab2.transform.localPosition = new Vector3((-gap * (j + 1)), 0, (-gap * (j + 1)));
            }
        }
    }
}