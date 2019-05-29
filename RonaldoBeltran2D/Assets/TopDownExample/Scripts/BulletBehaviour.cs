using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour{

    public float speed = 15;
    public Vector3 direction = Vector3.right;
    public float lifespan = 1.5f;
    // Start is called before the first frame update
    void Start(){
        Destroy (gameObject, lifespan);
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(direction * 2 * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D other) {
        //TODO: Damage or Destroy Enemys
        if (other.CompareTag("Hazard")){

        }
        if (other.CompareTag("CamArea")) {

        }
        Destroy (gameObject);
    }
}
