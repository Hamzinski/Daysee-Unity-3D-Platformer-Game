using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class optionsMenu : MonoBehaviour
{
  public AudioSource theme;
  private bool isFullScreen =true;
  
  public void SetQuality (int QualityIndex) {
      QualitySettings.SetQualityLevel(QualityIndex);

  }

  public void SetFullscreen(bool fullScreen){
      Screen.fullScreen=fullScreen;
      isFullScreen=fullScreen;
  }

  public void SetMusic(bool isMusic){
      theme.mute=!isMusic;
  }
}
