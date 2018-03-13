using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour 
{
    public GameObject eagleTarget;
    public bool isLeader;
    public float speed;
    public float mass;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 2.5f);
    }

    // Use this for initialization
    void Start () 
	{
        // Set leader after it spawns
		if(isLeader)
        {
            eagleTarget = GameObject.FindGameObjectWithTag("EagleTarget");
        } else {
            eagleTarget = null;
        }
	}
	
	// Update is called once per frame
	void Update () 
	{
        // Set leader behaviour
		if(isLeader)
        {
            transform.LookAt(eagleTarget.transform);
            transform.position = Vector3.MoveTowards(this.transform.position, eagleTarget.transform.position, speed * Time.deltaTime);
        }
	}
}