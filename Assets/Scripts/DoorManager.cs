using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{

    public int unlockedSwitches;
    Vector3 initialPosition;

    [SerializeField]
    private Vector3 openedPosition;

	void Start ()
    {
        unlockedSwitches = 0;
        initialPosition = transform.position;
        openedPosition = new Vector3(initialPosition.x, initialPosition.y + 10, initialPosition.z);
	}
	
	void Update ()
    {
        if (unlockedSwitches == 3)
        {
            transform.position = Vector3.Lerp(transform.position, openedPosition, 2 * Time.deltaTime);
        }

    }

    public void UnlockSwitch ()
    {
        if (unlockedSwitches <3)
        {
            unlockedSwitches++;
        }
    }

    #region Singleton
    private static DoorManager instance;
    private DoorManager () { }

    public static DoorManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("DoorManger.Instance es nula pero se esta intentando accederla");
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (this != instance)
                DestroyImmediate(this.gameObject);
        }
    }

    #endregion
}
