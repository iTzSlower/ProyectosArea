using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMovement : MonoBehaviour
{
    public float horizontalSpeed = 15;
    public float gravity = 9;
    public Collider2D playerCollider;
    public float jumpForce = 15;

    public float width { get { return playerCollider.bounds.size.x; } }
    public float height { get { return playerCollider.bounds.size.y; } }
    Vector3 leftCorner { get { return transform.position - (Vector3.right * width / 2); } }
    Vector3 rightCorner { get { return transform.position + (Vector3.right * width / 2); } }

    float verticalSpeed;
    bool grounded;
    float detectionDistance = 0.2f;

    void Start()
    {

    }

    void Update() {

        RaycastHit2D leftHit = Physics2D.Raycast(leftCorner, Vector3.down, detectionDistance);
        RaycastHit2D rightHit = Physics2D.Raycast(rightCorner, Vector3.down, detectionDistance);

        if (leftHit || rightHit) {
            grounded = true;
        } else {
            grounded = false;
        }

        Vector3 horizontalMovement = Vector3.right * Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        if (!grounded) {
            verticalSpeed -= gravity * Time.deltaTime;
        } else {
            if (verticalSpeed < 0) {
                verticalSpeed = 0;
                float distance = leftHit.distance;
                if (distance != 0) { distance = rightHit.distance; }
                transform.Translate(Vector3.down * distance);
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                verticalSpeed = jumpForce;
            }
        }
        Vector3 verticalMovement = Vector3.up * verticalSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement + verticalMovement);

    } 
    
   void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawRay (leftCorner, Vector3.down * detectionDistance);
        Gizmos.DrawRay (rightCorner, Vector3.down * detectionDistance);
        
        Gizmos.DrawSphere (transform.position - (Vector3.right * width / 2), 0.05f);
        Gizmos.DrawSphere (transform.position + (Vector3.right * width / 2), 0.05f);
   }
}
