﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{   
    public Transform followTarget;
    public float followSpeed;
    float minSpeed = 3.2f;
    Vector2 camUnitDimentions;
    public PlayerPhysicMov playerMovement;
    public float maxTargetDistance = 3.5f;
    Vector2 followPos { get { return followTarget.position; } }
    Vector2 cam2DPos { get { return followTarget.position; } }
    Vector2 limits { get { return playerMovement.limits - camUnitDimentions; } }
    Vector2 camfollowPoint { get {
            return followPos + playerMovement.mousePlayerDelta.normalized *
                Mathf.Clamp(playerMovement.mousePlayerDelta.magnitude, 0, maxTargetDistance);
      }
    }

    Vector3 tempfollowTarget { get { return tempTarget.position; } }
    public Transform tempTarget;
    float tempSpeed;

    
    float targetOrtographicSize = 1;

    // Start is called before the first frame update
    void Start () {
        camUnitDimentions = new Vector2(Camera.main.orthographicSize * 16 / 9, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void LateUpdate () {
        if (playerMovement) {

            Vector3 temp = tempTarget ? Vector3.MoveTowards(transform.position, tempfollowPoint, tempSpeed * Time.deltaTime);
            Vector3.MoveTowards (transform.position, camfollowPoint, minSpeed + (camfollowPoint - cam2DPos).magnitude * followSpeed * Time.deltaTime);
            temp.x = Mathf.Clamp(temp.x, -limits.x, limits.x);
            temp.y = Mathf.Clamp(temp.y, -limits.y, limits.y);
            temp.z = transform.position.z;
            transform.position = temp;
        }

        if (Camera.main.orthographicSize != targetOrtographicSize) {
            Camera.main.orthographicSize  = Mathf.MoveTowards(Camera.main.orthographicSize,targetOrtographicSize,5)
        }

    }
    public void SetTempTarget (Transform target = null, float speed = 0){
        tempTarget = target;
        tempSpeed = speed;
    }

    void OnDrawGizmos (){
        Gizmos.color = Color.green;
        Gizmos.DrawLine (cam2DPos, camfollowPoint);
        Gizmos.DrawWireSphere (cam2DPos, 0.35f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere (camfollowPoint, 0.35f);
    }
    
}