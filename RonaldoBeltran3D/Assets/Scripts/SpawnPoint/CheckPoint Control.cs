using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControl : MonoBehaviour {

    List<CheckPoint> checkPoints;
    CheckPoint activeCheckpoint;

    void Awake() {
        checkPoints = new List<CheckPoint>(FindObjectsOfType<CheckPoint>());
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void SetCurrentActive (CheckPoint current) {
        activeCheckpoint = current;
        activeCheckpoint.Activate(true);
        foreach (CheckPoint checkpoint in checkPoints.FindAll(point => point != activeCheckpoint)) {
            checkpoint.Activate(false);
        }
    }
}
