using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledMovement : MovScript
{
    public float gravity;
    public CharacterController characterController;
    Animator playerAnimator;
    float verticalSpeed;
    public float jumpforce = 10;
    bool lastGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit info;
        bool grounded = Physics.Raycast(transform.GetChild (0).position, Vector3.down, 0.25f);
        if (grounded)
        {
            verticalSpeed -= gravity * Time.deltaTime;
        } else
        {
            if (verticalSpeed < 0) { verticalSpeed = 0; }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log (verticalSpeed);
                verticalSpeed = jumpforce;
                playerAnimator.SetTrigger("Jump");
                Debug.Log (verticalSpeed);
            }
            if (lastGrounded != characterController.isGrounded) { playerAnimator.SetTrigger("Land"); }
            
        }
        lastGrounded = characterController.isGrounded;
        Vector3 forwardAxis = transform.forward * speed * Input.GetAxis("Vertical");
        Vector3 verticalAxis = Vector3.down * verticalSpeed;
        Vector3 horizontal = Vector3.up * Input.GetAxis("Horizontal");

        characterController.Move ((forwardAxis + verticalAxis) * Time.deltaTime);
    }

    void OnDrawGizmos () {

    }
}
