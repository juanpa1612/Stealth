using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    private Animator animMenu;
    private bool menuIsActive;

    [SerializeField]
    private Text txtHora;

	void Start ()
    {
        animMenu = GetComponent<Animator>();
        animMenu.SetBool("Active", false);
        animMenu.Play("Exit", 0, 1);
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuIsActive)
            {
                animMenu.SetBool("Active", true);
                menuIsActive = true;
                Time.timeScale = 0;
            }
            else
            {
                animMenu.SetBool("Active", false);
                menuIsActive = false;
                Time.timeScale = 1;
            }
        }
        txtHora.text = "20:" + (int)GameController.Instance.TiempoDeJuego;
    }
}
