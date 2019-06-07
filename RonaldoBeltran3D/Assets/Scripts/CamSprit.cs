using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSprit : MonoBehaviour
{
    public MovScript movingTarget;
    public Vector3 distanceFromTarget;
    Vector3 distancePoint { get { return movingTarget.position + movingTarget.EqualizeWithLocal (distanceFromTarget); } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (movingTarget) {
            transform.position = distancePoint;
            transform.rotation = movingTarget.transform.rotation;
        }
    }

    void OnDrawGizmos ()
    {
        if (movingTarget)
        {
            Gizmos.DrawWireSphere(distancePoint, 0.25f);
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(distancePoint, movingTarget.transform.position);
        }
    }
}
