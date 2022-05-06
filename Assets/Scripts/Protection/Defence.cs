using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{
  public void Activate(bool activate)
  {
    GetComponent<Renderer>().enabled = activate;
    GetComponent<Collider2D>().enabled = activate;
  }
}
