using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    [SerializeField]
    private Image sceneFadeImage;
    [SerializeField]
    private float sceneFadeDuration = 2;
    [SerializeField]
    private Text txtTiempoDeJuego;

    private void Awake()
    {
        sceneFadeImage.gameObject.SetActive(true);
    }

    void Start ()
    {
        sceneFadeImage.CrossFadeAlpha(0, sceneFadeDuration, true);
	}

    private void Update()
    {
        txtTiempoDeJuego.text = "20:" + (int) GameController.Instance.TiempoDeJuego;
    }
}
