using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
  public float sight;
  public float attackRange;
  public float angle;
  public LayerMask objectsLayers;
  public LayerMask obstaclesLayers;
  public Collider detectedObject;

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, sight);
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, attackRange);
    Gizmos.color = Color.green;
    Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
    Gizmos.DrawRay(transform.position, rightDirection * sight);
    Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
    Gizmos.DrawRay(transform.position, leftDirection * sight);
  }
  void Update()
  {
    Collider[] colliders = Physics.OverlapSphere(transform.position, sight, objectsLayers);

    for (int i = 0; i < colliders.Length; ++i)
    {
      Collider collider = colliders[i];
      Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);
      float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);
      if (angleToCollider < angle)
      {
        if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstaclesLayers))
        {
          Debug.DrawLine(transform.position, collider.bounds.center, Color.blue);
          if (collider.gameObject.CompareTag("Player"))
          {
            detectedObject = collider;
            float distance = Vector3.Distance(collider.ClosestPoint(transform.position), transform.position);
            if (distance < attackRange) {
              Debug.Log("Can Attack Enemy!");
              continue;
            }
            Debug.Log("See Enemy!");
          }
        }
        else
        {
          Debug.DrawLine(transform.position, hit.point, Color.yellow);
        }
      }
    }
  }
}
