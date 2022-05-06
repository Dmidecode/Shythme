using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protection : MonoBehaviour
{
  public Health Health { get; private set; }

  public Defence DefenceUp;

  public Defence DefenceDown;

  public Defence DefenceLeft;

  public Defence DefenceRight;

  void Awake()
  {
    this.Health = GetComponentInChildren<Health>();
  }

  private void Update()
  {
    if (PauseMenu.GameIsPaused) return;
    DefenceUp.Activate(false);
    DefenceDown.Activate(false);
    DefenceLeft.Activate(false);
    DefenceRight.Activate(false);

    if (Input.GetKey(KeyCode.Z))
    {
      DefenceUp.Activate(true);
    }
    else if (Input.GetKey(KeyCode.Q))
    {
      DefenceLeft.Activate(true);
    }
    else if (Input.GetKey(KeyCode.S))
    {
      DefenceDown.Activate(true);
    }
    else if (Input.GetKey(KeyCode.D))
    {
      DefenceRight.Activate(true);
    }
  }
}
