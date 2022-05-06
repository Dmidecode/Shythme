using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
  public AudioSource AudioClip;

  public PauseMenu PauseMenu;

  public Image ImageEnd;

  public void QuitGame()
  {
    SceneManager.LoadScene("MenuPrincipal");
  }

  public void Restart()
  {
    PauseMenu.ResumeGame();
    SceneManager.LoadScene("Level");
  }

  private void InitEnd()
  {
    AudioClip.ignoreListenerPause = true;
    AudioClip.Play();
  }

  public void DisplayVictory()
  {
    InitEnd();
    ImageEnd.sprite = Resources.Load<Sprite>("GameVictory");
  }

  public void DisplayGameOver()
  {
    InitEnd();
    ImageEnd.sprite = Resources.Load<Sprite>("GameOver");
  }
}
