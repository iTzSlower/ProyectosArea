using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtributes : MonoBehaviour {

    public int itemCount { get; private set; }

    // Start is called before the first frame update
    void Initialize() {
        itemCount = SceneControl.persitenPlayerData.itemCount;
        //transform.position = SceneControl.persistenPlayerData.position
        //transform.rotation = SceneControl.persistenPlayerData.rotation
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Item"))
        {
            itemCount++;
        }
    }
}
