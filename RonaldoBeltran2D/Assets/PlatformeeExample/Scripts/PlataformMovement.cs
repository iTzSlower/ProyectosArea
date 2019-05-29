using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMovement : MonoBehaviour
{
    public float horizontalSpeed = 15;
    public float gravity = 9;

    float verticalSpeed;

    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("horizontal") * horizontalSpeed * Time.deltaTime);
        verticalSpeed += gravity * Time.deltaTime;
        transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
    }
}
