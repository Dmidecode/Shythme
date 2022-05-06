using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  public int Life;

  public int NumberOfFlashes;

  public float IFramesDuration;

  private bool _isAlive;

  private bool invulnerable;

  private SpriteRenderer spriteRenderer;

  private Color baseColor;

  private void Awake()
  {
    this.spriteRenderer = GetComponent<SpriteRenderer>();
    this.baseColor = this.spriteRenderer.color;
  }

  public int GetLife()
  {
    return this.Life;
  }

  public bool IsAlive()
  {
    this._isAlive = this.Life > 0;
    return this._isAlive;
  }

  public void Heal(int heal)
  {
    this.Life = Mathf.Clamp(this.Life + heal, 0, 10);
  }

  public bool IsInvulnerable()
  {
    return this.invulnerable;
  }

  public void TakeDamage(int damage)
  {
    if (invulnerable) return;

    this.Life = Mathf.Clamp(this.Life - damage, 0, 10);
    StartCoroutine(Invunerability());
  }

  private IEnumerator Invunerability()
  {
    invulnerable = true;
    Physics2D.IgnoreLayerCollision(9, 10, true);

    for (int i = 0; i < NumberOfFlashes; i++)
    {
      this.spriteRenderer.color = new Color(1, 0, 0, 0.5f);
      yield return new WaitForSeconds(IFramesDuration / (NumberOfFlashes * 2));
      this.spriteRenderer.color = this.baseColor;
      yield return new WaitForSeconds(IFramesDuration / (NumberOfFlashes * 2));
    }

    Physics2D.IgnoreLayerCollision(9, 10, false);
    invulnerable = false;
  }
}
