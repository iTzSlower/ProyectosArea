using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledMovement : MovScript
{
    public float gravity;
    public CharacterController characterController;
    float verticalSpeed;
    public float jumpforce = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            verticalSpeed -= gravity * Time.deltaTime;
        } else
        {
            if (verticalSpeed < 0) { verticalSpeed = 0; }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log (verticalSpeed);
                verticalSpeed = jumpforce;
                Debug.Log (verticalSpeed);
            }
        }
        Vector3 forwardAxis = transform.forward * speed * Input.GetAxis("Vertical");
        Vector3 verticalAxis = Vector3.down * verticalSpeed;

        characterController.Move ((forwardAxis + verticalAxis) * Time.deltaTime);
    }
}
