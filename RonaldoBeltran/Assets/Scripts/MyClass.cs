using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass : MonoBehaviour {

    public int  number = 5;
    public Vector3 position;
    public GameObject cubeObject;

    // Start is called before the first frame update
    void Start() {
        GameObject testObject = new GameObject ();
        testObject.AddComponent<MeshFilter>().sharedMesh = cubeObject.GetComponent<MeshFilter>().sharedMesh;
        testObject.AddComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update() {
        
    }
}
