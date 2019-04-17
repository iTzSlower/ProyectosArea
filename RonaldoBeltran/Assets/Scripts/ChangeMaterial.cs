using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material oldMaterial;

    public Material newMaterial;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        oldMaterial = meshRenderer.material;
    }
    
    public void ChangeMaterialToNew()
    {
        meshRenderer.material = newMaterial;
    }
    public void ChangeMaterialOld()
    {
        meshRenderer.material = oldMaterial;
    }
}
