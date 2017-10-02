using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Image FadeInImage;
    [SerializeField]
    private float fadeDuration = 2;

    private void Start()
    {
        FadeInImage.CrossFadeAlpha(0, fadeDuration, true);
    }

    void Update ()
    {
        if (Input.anyKeyDown)
        {
            FadeInImage.CrossFadeAlpha(1, fadeDuration, true);
            Invoke("CambiarEscena", fadeDuration);
        }
	}

    public void CambiarEscena ()
    {
        SceneManager.LoadScene(1);
    }
}
