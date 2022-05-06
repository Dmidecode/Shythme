using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
  public Protection Protection;

  public TextMeshProUGUI UITextMeshPro;

  void Update()
  {
    UITextMeshPro.text = $"Life: {this.Protection.Health.GetLife()}";
  }
}
