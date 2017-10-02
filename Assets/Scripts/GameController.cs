using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float tiempoDeJuego;
    

    private void Start()
    {
        
    }

    private void Update()
    {
        tiempoDeJuego -= Time.deltaTime;
    }
    public float TiempoDeJuego
    {
        get
        {
            return tiempoDeJuego;
        }
    }
    #region Singleton
    private static GameController instance;
    private GameController () { }

    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameController.Instance es nula pero se esta intentando accederla");
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
