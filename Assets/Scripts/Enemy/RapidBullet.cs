using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidBullet : Bullet
{
  public float FullSpeed;
  public float TimeStartDash;
  public float StartSpeed;

  private float currentTimeStartDash;

  protected override void Update()
  {
    base.Update();

    float currentSpeed = currentTimeStartDash > TimeStartDash ? this.FullSpeed : this.StartSpeed;

    currentSpeed *= Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), currentSpeed);
    currentTimeStartDash += Time.deltaTime;
  }
}
