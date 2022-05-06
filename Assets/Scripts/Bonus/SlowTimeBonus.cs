using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimeBonus : Bonus
{
  public override void Collided(Collider2D collider)
  {
    StartCoroutine(SlowTimeEnumerator());
  }

  private IEnumerator SlowTimeEnumerator()
  {
    GameManager.Instance.StartTimerBonus(5);
    Time.timeScale = 0.5f;
    yield return new WaitForSecondsRealtime(5);
    Time.timeScale = 1;
    Destroy(this.gameObject);
  }
}
