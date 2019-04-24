using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementcontrol : MonoBehaviour {

    public float speed = 1;
    public float rotationSpeed = 1;
    public float horizontalJumpDistance = 1;
    public KeyCode positiveButton;
    public KeyCode negativeButton;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {
        //Vector3 tempVector = Vector3.zero;
        //tempVector.z = speed;
        //transform.position += tempVector * Time.deltaTime;
        Vector3 horizontal = Vector3.up * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 vertical = Vector3.forward * GetVerticalAxis() * speed * Time.deltaTime;

        transform.Translate ((vertical).normalized * speed * Time.deltaTime);
        transform.Rotate (horizontal * Time.deltaTime);
    }
      
    int GetVerticalAxis (){

        int up = 0, down = 0;

        if (Input.GetKey (positiveButton) || Input.GetKey (KeyCode.W)){
            up = 1;
        }
        if (Input.GetKey (negativeButton) || Input.GetKey(KeyCode.S)){
            down = 1;
        }

        return up - down;
    }

    void OnTrigerEnter() {
        Debug.Log("Entered Target Area");
    }
    void OntriggerExit() {
        Debug.Log("Existed Target Area");
    }
}