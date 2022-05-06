using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public int Damage;

  public int ScoreBullet;

  public TypeBullet TypeBullet;

  protected virtual void Update()
  {
    transform.rotation = LookAtDestination(new Vector3(0, 0, 0));
  }

  protected Quaternion LookAtDestination(Vector3 target)
  {
    Vector3 diff = target - transform.position;
    diff.Normalize();
    float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    return Quaternion.Euler(0f, 0f, rot_z - 90);
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Core")
    {
      var health = collision.GetComponent<Health>();
      if (!health.IsInvulnerable())
        GameManager.Instance.AddScoreTookBullet(this.TypeBullet);

      collision.GetComponent<Health>().TakeDamage(this.Damage);
      Destroy(this.gameObject);
    }
    else if (collision.tag == "Defence")
    {
      GameManager.Instance.AddScoreProtectBullet(this.TypeBullet);
      GameManager.Instance.Score += this.ScoreBullet;
      Destroy(this.gameObject);
    }
  }
}
