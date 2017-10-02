using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardState : MonoBehaviour
{
    private StateMachine stateMachine = new StateMachine();
    private GameObject player;
    private Vector3 playerOffset;
    private Vector3[] waypoints;
    static bool playerHasBeenDetected;
    float viewAngle;

    Transform playerTransform;

    [SerializeField]
    Light spothLight;
    [SerializeField]
    float speed;
    [SerializeField]
    Transform pathHolder;
    [SerializeField]
    float viewDistance;
    [SerializeField]
    LayerMask viewMask;
    [SerializeField]
    int GuardType = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerOffset = new Vector3(0,player.transform.position.y - transform.position.y, 0)*-1;

        viewAngle = spothLight.spotAngle;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }

        //Tipo De Guardia
        switch (GuardType)
        {
            case 1: //Patrulla
                {
                    this.stateMachine.ChangeState(new FollowPath(this.gameObject, this.speed, this.waypoints));
                }
                break;
            case 2: //Guardia
                {
                    //No hace nada
                }
                break;
            case 3: //Campanero
                {
                    //No hace nada
                }
                break;
        }
    }

    private void Update()
    {
        this.stateMachine.ExecuteStateUpdate();

        //Vio al jugador
        if (SeeingPlayer() || playerHasBeenDetected)
        {
            this.stateMachine.ChangeState(new FollowPlayer(this.gameObject, this.player, speed, this.playerOffset));
        }
        if (SeeingPlayer() && GuardType ==3)
        {
            this.stateMachine.ChangeState(new FollowPlayer(this.gameObject, this.player, speed, this.playerOffset));
            playerHasBeenDetected = true;
        }
    }

    public bool SeeingPlayer()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < viewDistance)
        {
            Vector3 dirToPlayer = (playerTransform.position - transform.position).normalized;
            float angleBetween = Vector3.Angle(transform.forward, dirToPlayer);
            if (angleBetween < viewAngle / 2f)
            {
                if (!Physics.Linecast(transform.position, playerTransform.position, viewMask))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }
}
