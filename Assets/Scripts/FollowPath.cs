using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : IState
{

    GameObject ownerGameObject;
    Vector3[] waypoints;
    float speed;
    int targetWaypointIndex = 1;

    public FollowPath (GameObject ownerGameObject,float speed, Vector3[] waypoints)
    {
        this.ownerGameObject = ownerGameObject;
        this.speed = speed;
        this.waypoints = waypoints;
    }

    public void Enter()
    {

    }

    public void Execute()
    {
       
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];
        ownerGameObject.transform.LookAt(targetWaypoint);
        ownerGameObject.transform.position = Vector3.MoveTowards(ownerGameObject.transform.position, targetWaypoint, speed * Time.deltaTime);

        if (ownerGameObject.transform.position == targetWaypoint )
        {
            targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
            targetWaypoint = waypoints[targetWaypointIndex];
        }
    }

    public void Exit()
    {
        
    }
}
