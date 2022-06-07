using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscript : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1f;
        
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);

    }

    public void QuitButton()
    {
        Application.Quit();

    }
}
