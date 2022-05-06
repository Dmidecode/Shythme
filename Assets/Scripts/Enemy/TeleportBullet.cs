using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBullet : Bullet
{
  public float Speed;
  public float TimeBeforeTeleport;

  private float currentTimeBeforeTeleport;

  protected override void Update()
  {
    base.Update();

    if (currentTimeBeforeTeleport > this.TimeBeforeTeleport)
    {
      transform.position = new Vector3(-transform.position.x, -transform.position.y, transform.position.z);
      currentTimeBeforeTeleport = 0;
    }

    float speed = this.Speed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), speed);

    currentTimeBeforeTeleport += Time.deltaTime;
  }
}
