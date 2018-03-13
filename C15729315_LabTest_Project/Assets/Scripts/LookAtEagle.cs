using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEagle : MonoBehaviour 
{
    public GameObject cameraTarget;
    public bool spawned = false;
	
	// Update is called once per frame
	void Update () 
	{
        // When the leader is spawned, get the camera to follow it
		if(spawned)
        {
            cameraTarget = GameObject.FindGameObjectWithTag("CameraTarget");
            transform.LookAt(cameraTarget.transform);
        }
	}
}