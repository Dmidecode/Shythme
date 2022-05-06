using Assets.Scripts.Util;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayStatsBullet : MonoBehaviour
{
  public TextMeshProUGUI ScoreNormalBulletProtected;
  public TextMeshProUGUI ScoreNormalBulletTaken;
  public TextMeshProUGUI ScoreRapidBulletProtected;
  public TextMeshProUGUI ScoreRapidBulletTaken;
  public TextMeshProUGUI ScoreTeleportBulletProtected;
  public TextMeshProUGUI ScoreTeleportBulletTaken;

  void Update()
  {
    DisplayScoreBullet();
  }

  public void DisplayScoreBullet()
  {
    ScoreNormalBulletProtected.text = GameManager.Instance.GetScoreBulletProtectedNormal().ToString();
    ScoreNormalBulletTaken.text = GameManager.Instance.GetScoreBulletTookNormal().ToString();
    ScoreRapidBulletProtected.text = GameManager.Instance.GetScoreBulletProtectedRapid().ToString();
    ScoreRapidBulletTaken.text = GameManager.Instance.GetScoreBulletTookRapid().ToString();
    ScoreTeleportBulletProtected.text = GameManager.Instance.GetScoreBulletProtectedTeleport().ToString();
    ScoreTeleportBulletTaken.text = GameManager.Instance.GetScoreBulletTookTeleport().ToString();
  }
}
