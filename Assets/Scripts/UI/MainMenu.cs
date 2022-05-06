using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public GameObject PrepareLevel;

  private void Awake()
  {
    Time.timeScale = 1;
    AudioListener.pause = false;
  }

  public void StartGame()
  {
    PrepareLevel.SetActive(true);
    this.gameObject.SetActive(false);
  }

  public void QuitGame()
  {
    Application.Quit();
  }

  public void Tutorial()
  {
    SceneManager.LoadScene("Tutorial");
  }
}
