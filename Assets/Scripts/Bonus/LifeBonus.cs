using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : Bonus
{
  public int Heal;

  public override void Collided(Collider2D collider)
  {
    var health = collider.GetComponent<Health>();
    if (health != null)
    {
      health.Heal(this.Heal);
    }

    Destroy(this.gameObject);
  }
}
