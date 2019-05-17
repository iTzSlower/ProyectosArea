using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour{

    public float speed = 2;
    public Vector3 direction = Vector3.right;
    public float lifespan = 2.5f;
    // Start is called before the first frame update
    void Start(){
        Destroy (gameObject, lifespan);
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(direction * 2 * Time.deltaTime);
    }

    void OnTriggerEnter2D () {
        //TODO: Damage or Destroy Enemys
        Destroy (gameObject);
    }
}
