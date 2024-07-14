using System.Collections.Generic;
using UnityEngine;

namespace GunRun.Scripts
{
    public class PlayerLookController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private List<GameObject> lookAttractors = new ();
        
        private void FixedUpdate()
        {
            UpdateLookDirection();
        }

        private void UpdateLookDirection()
        {
            var closestAttractionPoint = FindClosestAttractionPoint();
            var lookDirection = closestAttractionPoint - (Vector2)transform.position;
            var lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            rigidbody.rotation = lookAngle;
        }

        private Vector2 FindClosestAttractionPoint()
        {
            var closestAttractionPoint = Vector2.zero;
            var distanceToClosestObject = float.MaxValue;
            
            foreach (var lookAttractor in lookAttractors)
            {
                if (lookAttractor == null || !lookAttractor.activeInHierarchy) continue;
                var distanceToObject = Vector2.Distance(transform.position, lookAttractor.transform.position);
                if (distanceToObject < distanceToClosestObject)
                {
                    distanceToClosestObject = distanceToObject;
                    closestAttractionPoint = lookAttractor.transform.position;
                }
            }

            return closestAttractionPoint;
        }
    }
}