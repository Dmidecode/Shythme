using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBulletBonus : Bonus
{
  public override void Collided(Collider2D collider)
  {
    ShootRandombullet();
    ShootRandombullet();

    static void ShootRandombullet()
    {
      int rangeBullet = Random.Range(0, 3);
      switch (rangeBullet)
      {
        case 0:
          GameManager.Instance.ShootNormalBullet(ManageTempo.Instance.Difficulty);
          break;
        case 1:
          GameManager.Instance.ShootRapidBullet(ManageTempo.Instance.Difficulty);
          break;
        case 2:
          GameManager.Instance.ShootTeleportBullet(ManageTempo.Instance.Difficulty);
          break;
      }
    }

    Destroy(this.gameObject);
  }
}
