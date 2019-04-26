using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementcontrol : MonoBehaviour
{

    public float speed = 1;
    public float rotationSpeed = 1;
    public float horizontalJumpDistance = 1;
    public KeyCode positiveButton;
    public KeyCode negativeButton;

    Vector3 originalPos;
    Quaternion originalRot;

    int PointCount;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 tempVector = Vector3.zero;
        //tempVector.z = speed;
        //transform.position += tempVector * Time.deltaTime;
        Vector3 horizontal = Vector3.up * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector3 vertical = Vector3.forward * GetVerticalAxis() * speed * Time.deltaTime;

        transform.Translate(vertical * speed * Time.deltaTime);
        transform.Rotate(horizontal * rotationSpeed * Time.deltaTime);
    }

    int GetVerticalAxis()
    {

        int up = 0, down = 0;

        if (Input.GetKey(positiveButton) || Input.GetKey(KeyCode.W))
        {
            up = 1;
        }
        if (Input.GetKey(negativeButton) || Input.GetKey(KeyCode.S))
        {
            down = 1;
        }

        return up - down;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Hazard") {
            Debug.Log("I waws hit by " + other.name);
            transform.position = originalPos;
            transform.rotation = originalRot;
        }else if (other.tag == "Collectible") {
            PointCount++;
            Destroy (other.gameObject);
        }
    }

    void OnGUI ()
    {
        GUI.Label (new Rect(0, 0, 100, 50), "Points: " + PointCount);
    }
}