using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  public static bool GameIsPaused;

  public GameObject PauseMenuUI;

  public AudioSource Audio;

  public TextMeshProUGUI PercentVolume;

  public GameObject LevelUI;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (!GameIsPaused)
        PauseGame(false);
      else
        ResumeGame();
    }
  }

  public void ChangeVolume(float sliderValue)
  {
    Audio.volume = sliderValue;
    PercentVolume.text = $"{Mathf.FloorToInt(sliderValue * 100)} %";
  }

  public void PauseGame(bool gameOver)
  {
    if (!gameOver)
      PauseMenuUI.SetActive(true);

    GameIsPaused = true;
    Time.timeScale = 0;
    AudioListener.pause = true;
    LevelUI.SetActive(false);
  }

  public void ResumeGame()
  {
    GameIsPaused = false;
    PauseMenuUI.SetActive(false);
    Time.timeScale = 1;
    AudioListener.pause = false;
    LevelUI.SetActive(true);
  }

  public void QuitGame()
  {
    SceneManager.LoadScene("MenuPrincipal");
  }
}
