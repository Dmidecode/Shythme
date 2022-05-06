using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerSong : MonoBehaviour
{
  public TextMeshProUGUI Timer;


  float currentTimer;

  private void Start()
  {
    currentTimer = ManageTempo.Instance.GetLength();
  }

  private void Update()
  {
    if (currentTimer > 0)
      currentTimer -= Time.unscaledDeltaTime;

    Timer.text = $"Timer Left: {Mathf.FloorToInt(currentTimer / 60)}.{Mathf.FloorToInt(currentTimer % 60):00}";
  }
}
