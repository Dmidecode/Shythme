using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTempo : MonoBehaviour
{
  public float BeatPerMinute;

  private float currentTempo;

  public float BonusTempo;

  private float currentBonusTempo;

  AudioSource audioSource;

  public Difficulty Difficulty;

  private static ManageTempo instance;

  public static ManageTempo Instance => instance;

  public GameObject GameOverMenu;

  public PauseMenu PauseMenu;

  public AudioClip Aqua;
  public AudioClip Flower;
  public AudioClip Doubt;
  public AudioClip OZone;
  public AudioClip Friend;

  private void Awake()
  {
    if (instance != null && instance != this)
      Destroy(gameObject);

    instance = this;
    audioSource = GetComponent<AudioSource>();
    this.SetDifficulty(ConfigLevel.Instance.Difficulty);
    this.SetSong(ConfigLevel.Instance.Song);
  }

  void Update()
  {
    if (this.Difficulty == null) return;

    if (!audioSource.isPlaying)
    {
      if (audioSource.time >= audioSource.clip.length)
      {
        PauseMenu.PauseGame(true);
        GameOverMenu.SetActive(true);
        GameOverMenu.GetComponent<GameOverMenu>().DisplayVictory();
      }

      return;
    }

    currentTempo += Time.deltaTime;
    currentBonusTempo += Time.deltaTime;

    if (this.Difficulty.Bonus(currentBonusTempo, BonusTempo))
      currentBonusTempo = 0;

    if (this.Difficulty.Shooting(currentTempo, BeatPerMinute))
      currentTempo = 0;
  }

  public void SetSong(int song)
  {
    switch (song)
    {
      case 0:
        audioSource.clip = Aqua;
        break;
      case 1:
        audioSource.clip = Flower;
        break;
      case 2:
        audioSource.clip = Doubt;
        break;
      case 3:
        audioSource.clip = OZone;
        break;
      case 4:
        audioSource.clip = Friend;
        break;
    }

    audioSource.Play();
  }

  public float GetLength()
  {
    return this.audioSource.clip.length;
  }

  public void SetDifficulty(TypeDifficulty difficulty)
  {
    switch (difficulty)
    {
      case TypeDifficulty.Easy:
        this.Difficulty = GameObject.Find("EasyDifficulty").GetComponent<Difficulty>();
        break;
      case TypeDifficulty.Normal:
        this.Difficulty = GameObject.Find("NormalDifficulty").GetComponent<Difficulty>();
        break;
      case TypeDifficulty.Hard:
        this.Difficulty = GameObject.Find("HardDifficulty").GetComponent<Difficulty>();
        break;
      case TypeDifficulty.Extreme:
        this.Difficulty = GameObject.Find("ExtremeDifficulty").GetComponent<Difficulty>();
        break;
      case TypeDifficulty.Impossible:
        this.Difficulty = GameObject.Find("ImpossibleDifficulty").GetComponent<Difficulty>();
        break;
      case TypeDifficulty.Novice:
      default:
        this.Difficulty = GameObject.Find("NoviceDifficulty").GetComponent<Difficulty>();
        break;
    }
  }
}
