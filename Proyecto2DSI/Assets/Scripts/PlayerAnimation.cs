using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Start()
    {
        if(target != null){

            target.transform.parent = null;


        }
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }
    }
}
