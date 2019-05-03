using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horMove = Input.GetAxis("Horizontal") * Vector3.right;
        Vector3 verMove = Input.GetAxis("Vertical") * Vector3.up;

        transform.Translate((horMove + verMove).normalized * moveSpeed * Time.deltaTime);
    }
}
