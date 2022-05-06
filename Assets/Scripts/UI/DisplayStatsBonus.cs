using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStatsBonus : MonoBehaviour
{
  public TextMeshProUGUI ScoreLifeBonusProtected;
  public TextMeshProUGUI ScoreLifeBonusTaken;
  public TextMeshProUGUI ScoreSlowTimeBonusProtected;
  public TextMeshProUGUI ScoreSlowTimeBonusTaken;
  public TextMeshProUGUI ScoreFastTimeBonusProtected;
  public TextMeshProUGUI ScoreFastTimeBonusTaken;
  public TextMeshProUGUI ScoreDoubleBulletBonusProtected;
  public TextMeshProUGUI ScoreDoubleBulletBonusTaken;

  void Update()
  {
    DisplayScoreBonus();
  }

  public void DisplayScoreBonus()
  {
    ScoreLifeBonusProtected.text = GameManager.Instance.GetScoreBonusProtectedLife().ToString();
    ScoreLifeBonusTaken.text = GameManager.Instance.GetScoreBonusTookLife().ToString();
    ScoreSlowTimeBonusProtected.text = GameManager.Instance.GetScoreBonusProtectedSlowTime().ToString();
    ScoreSlowTimeBonusTaken.text = GameManager.Instance.GetScoreBonusTookSlowTime().ToString();
    ScoreFastTimeBonusProtected.text = GameManager.Instance.GetScoreBonusProtectedFastTime().ToString();
    ScoreFastTimeBonusTaken.text = GameManager.Instance.GetScoreBonusTookFastTime().ToString();
    ScoreDoubleBulletBonusProtected.text = GameManager.Instance.GetScoreBonusProtectedDoubleBullet().ToString();
    ScoreDoubleBulletBonusTaken.text = GameManager.Instance.GetScoreBonusTookDoubleBullet().ToString();
  }
}
