using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    Queue<string> spawnQueue;
    int activeEntityLimit;
    public float spawnDelay;
    float currentTimer;

    // Start is called before the first frame update
    void Start() {
        spawnQueue = new Queue<string> ();
        spawnQueue.Enqueue("cube");
        spawnQueue.Enqueue("sphere");

    }

    // Update is called once per frame
    void Update() {
        currentTimer += Time.deltaTime;
        ResetTimer(SpawnEntity);
    }

    void ResetTimer (Action action) {
        if (currentTimer >= spawnDelay) {
            action.Invoke();
            currentTimer = 0;
        }
    }

    void SpawnEntity () {
        if (spawnQueue.Count > 0) {
            SpawnableEntity next = SpawnManager.instance.Search (spawnQueue.Dequeue());
            next.Create (transform.position, Quaternion.identity);
        } else {
            Debug.LogWarning ("Empty Queue");
        }
    }

    void OnDrawGizmos () {
        Gizmos.DrawSphere(transform.position, 1);
    }
}
