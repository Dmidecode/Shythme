using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
  public TextMeshProUGUI Score;

  void Update()
  {
    Score.text = GameManager.Instance.Score.ToString();
  }
}
