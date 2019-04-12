using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementcontrol : MonoBehaviour
{

    public float speed = 1;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update() {
        //Vector3 tempVector = Vector3.zero;
        //tempVector.z = speed;
        //gameObject.transform.position += tempVector * Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow)) {
            Vector3 tempVector = Vector3.zero;
            tempVector.z = speed;
            gameObject.transform.position += tempVector * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 tempVector = Vector3.zero;
            tempVector.z = -speed;
            gameObject.transform.position += tempVector * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 tempVector = Vector3.zero;
            tempVector.x = -speed;
            gameObject.transform.position += tempVector * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 tempVector = Vector3.zero;
            tempVector.x = speed;
            gameObject.transform.position += tempVector * Time.deltaTime;
        }
    }
}
