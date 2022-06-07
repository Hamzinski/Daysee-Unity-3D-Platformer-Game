using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class menucontroller : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject Pausee;
    public GameObject optionsMenu;
    public GameObject panel;
    public AudioSource theme;
    public GameObject player;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {

            if(gameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
            }
        }

        public void Resume() {
            Pausee.SetActive(false);
            Time.timeScale = 1f;
            //pauseMenu.SetActive(false);
            //panel.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
            gameIsPaused = false;
        }

        public void Pause() {
            Pausee.SetActive(true);
            Time.timeScale = 0f;
            //pauseMenu.SetActive(true);
            //panel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameIsPaused = true;

        }

        public void LoadScene() {
            SceneManager.LoadScene(0);
        }

        public void ShowOptions() {
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(true);
            //gameIsPaused = true;
        }

        public void SetQuality(int qual) {
            QualitySettings.SetQualityLevel(qual);
        }

        public void SetFullscreen(bool isFull) {
            Screen.fullScreen = isFull;
        }

        public void SetMusic(bool isMusic) {
            theme.mute = !isMusic;
        }      
    }

