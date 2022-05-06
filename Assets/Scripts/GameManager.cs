using Assets.Scripts.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject NormalBullet;
  public GameObject RapidBullet;
  public GameObject TeleportBullet;

  public GameObject[] Bonus;
  public GameObject[] Malus;

  private int[] NumberBulletProtected;
  private int[] NumberBulletTook;

  private int[] NumberBonusProtected;
  private int[] NumberBonusTook;

  public int Score;

  private static GameManager instance;

  public static GameManager Instance => instance;

  public Health Life;

  public GameObject GameOverMenu;

  public PauseMenu PauseMenu;

  public TimerBonus TimerBonus;

  private void Awake()
  {
    if (instance != null && instance != this)
      Destroy(gameObject);

    instance = this;

    NumberBulletProtected = new int[Enum.GetValues(typeof(TypeBullet)).Length];
    NumberBulletTook = new int[Enum.GetValues(typeof(TypeBullet)).Length];

    NumberBonusProtected = new int[Enum.GetValues(typeof(TypeBonus)).Length];
    NumberBonusTook = new int[Enum.GetValues(typeof(TypeBonus)).Length];
  }

  void Update()
  {
    if (!Life.IsAlive() && !GameOverMenu.activeInHierarchy)
    {
      PauseMenu.PauseGame(true);
      GameOverMenu.SetActive(true);
      GameOverMenu.GetComponent<GameOverMenu>().DisplayGameOver();
    }
  }

  public void StartTimerBonus(float seconds)
  {
    TimerBonus.StartTimer(seconds);
  }

  public void ShootNormalBullet(Difficulty difficulty)
  {
    var bullet = Instantiate(NormalBullet, GetRandomOrigin(), Quaternion.identity);
    bullet.GetComponent<NormalBullet>().Speed *= difficulty.GetModifierSpeed();
  }

  public void ShootRapidBullet(Difficulty difficulty)
  {
    var bullet = Instantiate(RapidBullet, GetRandomOrigin(), Quaternion.identity);
    bullet.GetComponent<RapidBullet>().FullSpeed *= difficulty.GetModifierSpeed();
    bullet.GetComponent<RapidBullet>().StartSpeed *= difficulty.GetModifierSpeed();
  }

  public void ShootTeleportBullet(Difficulty difficulty)
  {
    Instantiate(TeleportBullet, GetRandomOrigin(), Quaternion.identity);
  }

  public void ShootBonus()
  {
    int indexBonus = UnityEngine.Random.Range(0, Bonus.Length);
    Instantiate(Bonus[indexBonus], GetRandomOrigin(), Quaternion.identity);
  }

  public void ShootMalus()
  {
    int indexMalus = UnityEngine.Random.Range(0, Malus.Length);
    Instantiate(Malus[indexMalus], GetRandomOrigin(), Quaternion.identity);
  }

  #region Score Bullet
  public int GetScoreBulletProtectedNormal()
  {
    return this.NumberBulletProtected[(int)TypeBullet.Normal];
  }

  public int GetScoreBulletTookNormal()
  {
    return this.NumberBulletTook[(int)TypeBullet.Normal];
  }

  public int GetScoreBulletProtectedRapid()
  {
    return this.NumberBulletProtected[(int)TypeBullet.Rapid];
  }

  public int GetScoreBulletTookRapid()
  {
    return this.NumberBulletTook[(int)TypeBullet.Rapid];
  }

  public int GetScoreBulletProtectedTeleport()
  {
    return this.NumberBulletProtected[(int)TypeBullet.Teleport];
  }

  public int GetScoreBulletTookTeleport()
  {
    return this.NumberBulletTook[(int)TypeBullet.Teleport];
  }

  public void AddScoreProtectBullet(TypeBullet typeBullet)
  {
    this.NumberBulletProtected[(int)typeBullet] += 1;
  }

  public void AddScoreTookBullet(TypeBullet typeBullet)
  {
    this.NumberBulletTook[(int)typeBullet] += 1;
  }
  #endregion

  #region Score Bonus
  public int GetScoreBonusProtectedLife()
  {
    return this.NumberBonusProtected[(int)TypeBonus.Life];
  }

  public int GetScoreBonusTookLife()
  {
    return this.NumberBonusTook[(int)TypeBonus.Life];
  }

  public int GetScoreBonusProtectedSlowTime()
  {
    return this.NumberBonusProtected[(int)TypeBonus.SlowTime];
  }

  public int GetScoreBonusTookSlowTime()
  {
    return this.NumberBonusTook[(int)TypeBonus.SlowTime];
  }

  public int GetScoreBonusProtectedFastTime()
  {
    return this.NumberBonusProtected[(int)TypeBonus.FastTime];
  }

  public int GetScoreBonusTookFastTime()
  {
    return this.NumberBonusTook[(int)TypeBonus.FastTime];
  }
  public int GetScoreBonusProtectedDoubleBullet()
  {
    return this.NumberBonusProtected[(int)TypeBonus.DoubleBullet];
  }

  public int GetScoreBonusTookDoubleBullet()
  {
    return this.NumberBonusTook[(int)TypeBonus.DoubleBullet];
  }

  public void AddScoreProtectBonus(TypeBonus typeBonus)
  {
    this.NumberBonusProtected[(int)typeBonus] += 1;
  }

  public void AddScoreTookBonus(TypeBonus typeBonus)
  {
    this.NumberBonusTook[(int)typeBonus] += 1;
  }
  #endregion

  private Vector3 GetRandomOrigin()
  {
    return UnityEngine.Random.insideUnitCircle.normalized * 35;
  }
}
