﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlataform : Activable {

    List<Vector3> movePoints;
    int targetPoint;
    int direction = 1;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (currentlyActive && movePoints.Count > 1) {
            //TODO: Move the platform
            transform.position = Vector3.MoveTowards(transform.position, movePoints[targetPoint], 2 * Time.deltaTime);
            if (transform.position == movePoints[targetPoint]) {
                if ((targetPoint == movePoints.Count - 1) || targetPoint == 0 && direction < 0) {direction *= -1; }
                targetPoint += direction;
            }
        }
    }

    void OnDrawGizmos () {
        if (movePoints.Count > 1) {
            foreach (Vector3 point in movePoints) {
                Gizmos.DrawCube (transform.TransformPoint(point), Vector3.one * 0.5f);
            }
        }
    }
}
