using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions 
{
    public static Transform GetClosestObject(this Transform transform, ref List<GameObject> scaryObjects)
    {
        if (scaryObjects.Count <= 0)
            return null;

        Transform closestObject = null;
        float currentClosesDistance = float.MaxValue; // Math.Infinity

        foreach (GameObject item in scaryObjects)
        {
            float distance = Vector2.Distance(transform.position, item.transform.position);
            if (distance < currentClosesDistance)
            {
                currentClosesDistance = distance;
                closestObject = item.transform;
            }
        }

        return closestObject;
    }
}
