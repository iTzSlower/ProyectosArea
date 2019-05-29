using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicMov : MonoBehaviour
{
    public float moveSpeed = 15;
    public Vector2 limits = new Vector2(16, 9);
    Vector2 shapeLimits { get { return limits - ((colliderSize * transform.localScale) / 2); } }
    Vector2 colliderSize;
    Rigidbody2D rb2D;
    Vector2 currentMouseWorldPos;
    public Vector2 current2DPos { get { return transform.position; } }
    public Vector2 mousePlayerDelta
    {
        get
        {
            return !rb2D ? Vector2.zero : currentMouseWorldPos - rb2D.position;
        }
    }

    public float bulletOriginDist = 1.3f;
    public GameObject bulletPrefab;

    public float fireRate = 2;
    public float cooldownTimer = 0.0f;
    public bool isOnCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        colliderSize = gameObject.GetComponent<BoxCollider2D>().size;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Get Current Horizontal Movement
        Vector2 horMove = Input.GetAxisRaw("Horizontal") * Vector2.right;
        //Get Current Vertical Movement
        Vector2 verMove = Input.GetAxisRaw("Vertical") * Vector2.up;

        if (rb2D)
        {
            Vector2 movement = rb2D.position + ((horMove + verMove).normalized * moveSpeed * Time.fixedDeltaTime);
            movement.x = Mathf.Clamp(movement.x, -shapeLimits.x, shapeLimits.x);
            movement.y = Mathf.Clamp(movement.y, -shapeLimits.y, shapeLimits.y);
            rb2D.MovePosition(movement);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            //TODO: Kill player
        }

        if (other.CompareTag("CamArea"))
        {
            CamArea targetArea = other.GetComponent<CamArea>();
            Camera.main.GetComponent<CamMovement>().SetTempTarget(targetArea.transform, targetArea.centerSpeed, targetArea.targetSize);
        }
        if (other.CompareTag("Exit"))
        {

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("CamArea"))
        {
            Camera.main.GetComponent<CamMovement>().SetTempTarget();
        }
    }

    void Update()
    {
        currentMouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!isOnCooldown)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                isOnCooldown = true;
            }
        }
        else
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= 1 / fireRate)
            {
                cooldownTimer = 0;
                isOnCooldown = false;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, current2DPos + (mousePlayerDelta.normalized * bulletOriginDist), Quaternion.identity);
        bullet.GetComponent<BulletBehaviour>().direction = mousePlayerDelta.normalized;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 50), "MousePos: " + currentMouseWorldPos);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.15f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, limits * 2);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(Vector3.zero, shapeLimits * 2);
        Gizmos.DrawLine(transform.position, currentMouseWorldPos);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(currentMouseWorldPos, 0.25f);
    }
}