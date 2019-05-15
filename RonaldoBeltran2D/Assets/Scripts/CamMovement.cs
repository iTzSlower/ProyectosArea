using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform followTarget;
    public float followSpeed;
    Vector2 camUnitDimentions;
    public PlayerPhysicMov playerMovement;
    Vector2 limits { get { return playerMovement.limits - camUnitDimentions; } }

    // Start is called before the first frame update
    void Start()
    {
        camUnitDimentions = new Vector2(Camera.main.orthographicSize * 16 / 9, Camera.main.orthographicSize);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (followTarget)
        {
            /*Vector3 temp = Vector3.MoveTowards (transform.position, followTarget.position, followSpeed * Time.deltaTime);
            temp.z = transform.position.z;
            transform.position = temp;*/
            Vector3 direction = (followTarget.position - transform.position).normalized;

            Vector3 temp = transform.position;
            transform.Translate(direction * followSpeed * Time.deltaTime);
            temp.x = Mathf.Clamp(transform.position.x, -limits.x, limits.x);
            temp.y = Mathf.Clamp(transform.position.y, -limits.y, limits.y);
            transform.position = temp;
        }
    }
    
}