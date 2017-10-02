using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeingPlayer : MonoBehaviour
{

    [SerializeField]
    float viewDistance;
    [SerializeField]
    LayerMask viewMask;

    float viewAngle;
    Light spothLight;
    Transform playerTransform;

    private void Start()
    {
        spothLight = GetComponent<Light>();
        viewAngle = spothLight.spotAngle;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public bool _SeeingPlayer()
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
}
