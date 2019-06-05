using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownCharAnim : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float moveSpeed = 50;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void ControllerFixedUpdate()
    {
        Vector2 horizontal = Input.GetAxisRaw("Horizontal") * Vector2.right;
        Vector2 vertical = Input.GetAxisRaw("Vertical") * Vector2.right;
    }
}
