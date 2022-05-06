using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrepareLevel : MonoBehaviour
{
  public GameObject MainMenu;

  public TextMeshProUGUI DifficultyText;

  public void StartLevel()
  {
    SceneManager.LoadScene("Level");
  }

  public void Cancel()
  {
    MainMenu.SetActive(true);
    this.gameObject.SetActive(false);
  }

  public void ChangeSong(int song)
  {
    ConfigLevel.Instance.Song = song;
  }

  public void ChangeDifficulty(float value)
  {
    TypeDifficulty difficulty = (TypeDifficulty)value;
    DifficultyText.text = difficulty.ToString();
    switch (difficulty)
    {
      case TypeDifficulty.Easy:
        DifficultyText.color = Color.cyan;
        break;
      case TypeDifficulty.Normal:
        DifficultyText.color = Color.green;
        break;
      case TypeDifficulty.Hard:
        DifficultyText.color = Color.magenta;
        break;
      case TypeDifficulty.Extreme:
        DifficultyText.color = Color.red;
        break;
      case TypeDifficulty.Impossible:
        DifficultyText.color = Color.black;
        break;
      case TypeDifficulty.Novice:
      default:
        DifficultyText.color = Color.white;
        break;
    }

    ConfigLevel.Instance.Difficulty = difficulty;
  }
}
