using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMovement : MonoBehaviour
{
    public float speed = 1;
    public Vector3 point;
    public Vector3 axis = Vector3.back;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(point, axis, 12 * Time.deltaTime);
        transform.rotation = Quaternion.identity;
    }

    void OnDrawGizmos (){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere (point, (point - transform.position).magnitude);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, (point - transform.position));
        Gizmos.DrawSphere(point, 0.25f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay (transform.position, transform.up);
        Gizmos.DrawRay (transform.position, transform.right);

    }
    void OnGUI (){
        GUI.Label (new Rect(10, 10, 100, 50), "Current Position" + transform.position);
    }
}
