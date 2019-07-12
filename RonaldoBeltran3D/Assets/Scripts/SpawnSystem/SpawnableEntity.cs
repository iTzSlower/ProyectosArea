using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableEntity : MonoBehaviour {

    public string id;

    public void Create (Vector3 position, Quaternion rotation) {
        Instantiate(gameObject, position, rotation);
    }
}
