using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveControl : MonoBehaviour
{
    public GameObject targetWall;
    public int remaniningEnemies;

    // Start is called before the first frame update
    void Start()
    {
        remaniningEnemies = GameObject.FindGameObjectsWithTag("Hazard").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (remaniningEnemies <= 0 && targetWall)
        {
            DestroyObject
        }
    }
}
