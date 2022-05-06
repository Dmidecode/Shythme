using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigLevel : MonoBehaviour
{
  public TypeDifficulty Difficulty;

  public int Song;

  private static ConfigLevel instance;

  public static ConfigLevel Instance => instance;

  private void Awake()
  {
    if (instance != null && instance != this)
      Destroy(gameObject);

    instance = this;
    DontDestroyOnLoad(gameObject);
  }
}
