using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
  public float Speed;

  protected override void Update()
  {
    base.Update();
    float speed = this.Speed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), speed);
  }
}
