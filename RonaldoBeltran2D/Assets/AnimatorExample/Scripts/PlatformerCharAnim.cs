using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerCharAnim : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float moveSpeed;
    public float JumpForce = 15;
    float gravity = 10;
    float vertSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void ControllerFixedUpdate ()
    {
        Vector2 horizontal = Input.GetAxisRaw("Horizontal") * Vector2.right;
        Vector2 vertical = Vector2.up * vertSpeed * Time.fixedDeltaTime;
    }
}
