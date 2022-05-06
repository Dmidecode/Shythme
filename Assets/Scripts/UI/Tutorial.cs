using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
  private void Awake()
  {
    Time.timeScale = 0;
    AudioListener.pause = true;
  }

  public void MenuPrincipal()
  {
    SceneManager.LoadScene("MenuPrincipal");
  }
}
