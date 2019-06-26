using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public PointData pointData { get; private set; }
    bool active;

    // Awake is called before the first frame update AND THE START :D
    void Awake() {
        pointData = new PointData(transform.position + Vector3.up, transform.rotation);
    }

    // Update is called once per frame
    public void Activate (bool setActive) {
        active = setActive;
        Renderer rend = GetComponent<Renderer>();
        if (active) {
            rend.material.color = Color.green;
        } else {
            rend.material.color = Color.white;
        }
    }
}
