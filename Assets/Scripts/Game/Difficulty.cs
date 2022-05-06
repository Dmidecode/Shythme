using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
  public TypeDifficulty TypeDifficulty;

  public float ModifierSpeed;

  public float ModifierFrequency;

  public bool Bonus(float currentBonusTempo, float bonusTempo)
  {
    if (currentBonusTempo > bonusTempo)
    {
      // Novice > Malus
      // Bonus < Impossible
      if (TypeDifficulty == TypeDifficulty.Novice)
        GameManager.Instance.ShootBonus();
      else if (TypeDifficulty == TypeDifficulty.Impossible)
        GameManager.Instance.ShootMalus();
      else if (RandomBool())
        GameManager.Instance.ShootBonus();
      else
        GameManager.Instance.ShootMalus();
      return true;
    }

    return false;
  }

  public bool Shooting(float currentTempo, float beatPerSecond)
  {
    if (currentTempo > beatPerSecond * ModifierFrequency)
    {
      int rangeBullet = Random.Range(0, Mathf.Min((int)TypeDifficulty + 1, 3));
      switch (rangeBullet)
      {
        case 0:
          GameManager.Instance.ShootNormalBullet(this);
          break;
        case 1:
          GameManager.Instance.ShootRapidBullet(this);
          break;
        case 2:
          GameManager.Instance.ShootTeleportBullet(this);
          break;
      }

      return true;
    }

    return false;
  }

  public float GetModifierSpeed()
  {
    return ModifierSpeed;
  }

  private bool RandomBool()
  {
    int value = UnityEngine.Random.Range(1, 101);
    return value % 2 == 0;
  }
}
