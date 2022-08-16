using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinBehavior : MonoBehaviour
{
  Animator anim;

  void Start()
  {
    anim = GetComponent<Animator>();
  }

  void Update()
  {
    /* Attack */ 
    if (Input.GetKeyDown(KeyCode.I))
    {
      anim.SetTrigger("Attack");
    }

    /* Block */ 
    if (Input.GetKeyDown(KeyCode.O))
    {
      anim.SetTrigger("Block");
    }    
    /* Hurt (be hit) */ 
    if (Input.GetKeyDown(KeyCode.P))
    {
      anim.SetTrigger("Hurt");
    }

    /* Walk Forward */ 
    if (Input.GetKeyDown(KeyCode.W))
    {
      anim.SetBool("isWalkingForward", true);
    }
    if (Input.GetKeyUp(KeyCode.W))
    {
      anim.SetBool("isWalkingForward", false);
    }

    /* Walk Back */ 
    if (Input.GetKeyDown(KeyCode.S))
    {
      anim.SetBool("isWalkingBack", true);
    }
    if (Input.GetKeyUp(KeyCode.S))
    {
      anim.SetBool("isWalkingBack", false);
    }

    /* Strafe Right (default strafe direction) */ 
    if (Input.GetKeyDown(KeyCode.A))
    {
      anim.SetBool("isStrafingRight", true);
    }
    if (Input.GetKeyUp(KeyCode.A))
    {
      anim.SetBool("isStrafingRight", false);
    }

    /* Strafe Right (alternate strafe direction) */ 
    if (Input.GetKeyDown(KeyCode.D))
    {
      anim.SetBool("isStrafingLeft", true);
    }
    if (Input.GetKeyUp(KeyCode.D))
    {
      anim.SetBool("isStrafingLeft", false);
    }

    /* Die */ 
    if (Input.GetKeyDown(KeyCode.U))
    {
      anim.SetBool("isDead", true);
    }
    if (Input.GetKeyUp(KeyCode.U))
    {
      anim.SetBool("isDead", false);
    }
  }
}
