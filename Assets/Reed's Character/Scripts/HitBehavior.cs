using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehavior : MonoBehaviour
{
  public bool isHit = false;
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Fist"))
    /* Include any tags here that are on the objects with colliders that will
       attack the enemy. E.g. fist, foot, etc. */
    {
      isHit = true;
    }
  }


}
