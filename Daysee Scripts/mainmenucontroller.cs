using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class mainmenucontroller : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject optionsMenu;
   public AudioSource theme;

    void Update()
    {
       
    }
     public void ShowOptions() {
            startmenu.SetActive(false);
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
