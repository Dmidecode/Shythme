using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
  public float Speed;

  public TypeBonus TypeBonus;

  private float degrees;

  protected void Update()
  {
    float speed = this.Speed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), speed);
    transform.eulerAngles = Vector3.forward * degrees;
    degrees += 1f;
  }

  public abstract void Collided(Collider2D collider);

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Core")
    {
      GameManager.Instance.AddScoreTookBonus(this.TypeBonus);
      GetComponent<SpriteRenderer>().enabled = false;
      this.Collided(collision);
    }
    else if (collision.tag == "Defence")
    {
      GameManager.Instance.AddScoreProtectBonus(this.TypeBonus);
      Destroy(this.gameObject);
    }
  }
}
