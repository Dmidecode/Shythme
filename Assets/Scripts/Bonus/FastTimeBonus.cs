using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTimeBonus : Bonus
{
  public override void Collided(Collider2D collider)
  {
    StartCoroutine(FastTimeEnumerator());
  }

  private IEnumerator FastTimeEnumerator()
  {
    GameManager.Instance.StartTimerBonus(5);
    Time.timeScale = 1.5f;
    yield return new WaitForSecondsRealtime(5);
    Time.timeScale = 1;

    Destroy(this.gameObject);
  }
}
