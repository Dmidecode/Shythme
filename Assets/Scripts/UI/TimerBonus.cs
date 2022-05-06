using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerBonus : MonoBehaviour
{
  private float SecondsLeft;

  private TMP_Text mesh;

  private void Awake()
  {
    mesh = GetComponent<TMP_Text>();
  }

  void Update()
  {
    if (SecondsLeft > 0)
    {
      mesh.enabled = true;
      mesh.text = $"Bonus: {FormatTimer()}";
      SecondsLeft -= Time.unscaledDeltaTime;
    }
    else
      mesh.enabled = false;
  }

  public void StartTimer(float seconds)
  {
    SecondsLeft = seconds;
  }

  private string FormatTimer()
  {
    int second = (int)SecondsLeft;
    float millisecond = SecondsLeft * 1000;
    millisecond %= 1000;
    return $"{second:00}:{millisecond:000}";
  }
}
