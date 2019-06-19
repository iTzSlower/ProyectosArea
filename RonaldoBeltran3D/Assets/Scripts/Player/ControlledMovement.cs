using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledMovement : MovScript
{

    public float gravity;
    public CharacterController characterController;
    Animator playerAnimator;
    float verticalSpeed;
    public float jumpForce = 10;
    bool grounded { get { return groundCount > 0 || persistence; } }
    int groundCount { get { return groundCollection.Count; } }
    List<Ground> groundCollection = new List<Ground>();
    bool persistence;

    class Ground
    {
        public Collider collider;
        public Vector3 contactNormal;

        public Ground(Collider collider, Vector3 contactNormal)
        {
            this.collider = collider;
            this.contactNormal = contactNormal;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
        characterController.detectCollisions = false;
    }

    // Update is called once per frame
    void Update()
    {
        //bool grounded = Physics.Raycast(transform.GetChild (0).position, Vector3.down, 0.15f);
        if (!grounded)
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        else
        {
            verticalSpeed = persistence ? verticalSpeed - (gravity * Time.deltaTime) : 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(verticalSpeed);
                verticalSpeed = jumpForce;
                Debug.Log(verticalSpeed);
            }
        }
        Vector3 forwardAxis = transform.forward * speed * Input.GetAxis("Vertical");
        Vector3 verticalAxis = Vector3.up * verticalSpeed;
        Vector3 horizontal = Vector3.up * Input.GetAxis("Horizontal");

        playerAnimator.SetBool("Grounded", grounded);

        characterController.Move((forwardAxis + verticalAxis) * Time.deltaTime);
        transform.Rotate(horizontal * angularSpeed * Time.deltaTime);
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collided " + collision.collider.name + " " + groundCount + "/" + persistence);
        Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.red);

        for (int i = 0; i < collision.contactCount; i++)
        {
            if (Vector3.Dot(collision.contacts[i].normal, Vector3.up) > 0.8)
            {
                if (groundCollection.Find(ground => ground.collider == collision.collider) == null)
                {
                    groundCollection.Add(new Ground(collision.collider, collision.contacts[i].normal));
                }
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Ground exitGround = groundCollection.Find(ground => ground.collider == collision.collider);
        if (exitGround != null)
        {
            persistence = Vector3.Dot(exitGround.contactNormal, Vector3.up) < 1 && verticalSpeed <= 0;
            groundCollection.Remove(exitGround);
            StartCoroutine(RecheckPersistance());
        }
        Debug.Log(persistence);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.GetChild(0).position, Vector3.down * 0.15f);
    }

    IEnumerator RecheckPersistance()
    {
        yield return new WaitForSeconds(0.25f);
        persistence = false;
    }
}