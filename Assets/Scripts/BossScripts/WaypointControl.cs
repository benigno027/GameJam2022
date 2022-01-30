using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointControl : MonoBehaviour {

	public GameObject waypointObject;
	
	Transform[] waypoints;

	[SerializeField]
	float moveSpeed = 2f;

	int waypointIndex = 0;

	void Start () {
		waypoints = waypointObject.GetComponent<Waypoint>().waypoints;
		transform.position = waypoints [waypointIndex].transform.position;
	}

	void Update () {
		Move ();
	}

	void Move()
	{
		transform.position = Vector2.MoveTowards (transform.position,
												waypoints[waypointIndex].transform.position,
												moveSpeed * Time.deltaTime);

		if (transform.position == waypoints [waypointIndex].transform.position) {
			waypointIndex += 1;
		}
				
		if (waypointIndex == waypoints.Length)
			waypointIndex = 0;
	}

}
