using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : IState
{
    float speed;
    float graceTime;
    GameObject ownerGameObject;
    GameObject player;
    Vector3 playerOffset;

    public FollowPlayer (GameObject ownerGameObject, GameObject player, float speed,Vector3 playerOffset/*float graceTime*/)
    {
        this.ownerGameObject = ownerGameObject;
        this.player = player;
        this.speed = speed;
        this.playerOffset = playerOffset;
        /*this.graceTime = graceTime;*/
    }

    public void Enter ()
    {
        graceTime = 5;
    }
    public void Execute ()
    {
        if (graceTime >0)
        {
            ownerGameObject.transform.position = Vector3.MoveTowards(ownerGameObject.transform.position,
    player.transform.position + playerOffset, speed * Time.deltaTime);
            ownerGameObject.transform.LookAt(player.transform.position + playerOffset);
            ownerGameObject.GetComponentInChildren<Light>().color = Color.red;
            graceTime -= Time.deltaTime;
        }        
    }
    public void Exit ()
    {
        //ownerGameObject.GetComponentInChildren<Light>().color = Color.blue;
    }
}
