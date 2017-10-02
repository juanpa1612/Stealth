using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    bool hasBeenActivated;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F) && !hasBeenActivated)
            {
                DoorManager.Instance.UnlockSwitch();
                hasBeenActivated = true;
            }
        }
    }
}
