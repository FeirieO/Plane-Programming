using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    int currentWaypointIndex = 0;

    [SerializeField] float speed = 1.0f;

    // in each object, we check how far we are from the current waypoint, if we touch the currentwaypoint , it switches to the next one, if not, we don't switch to the next one 
    void Update()
    {
        if (Vector3.Distance(transform.position, wayPoints[currentWaypointIndex].transform.position) < .1f)
        {
            currentWaypointIndex++; //currentWaypointIndex = currentWaypointIndex + 1;
            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        //we move towards the current active waypoint by calculating a new position between the platform position and the currently active waypoint, calculate with speed to move the frame per seconds
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
