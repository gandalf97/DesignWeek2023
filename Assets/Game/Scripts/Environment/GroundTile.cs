using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider), typeof(MeshRenderer))]
public class GroundTile : MonoBehaviour
{
    public bool isWet;
    [SerializeField] private PhysicMaterial wetPhysicsMaterial;
    [SerializeField] private PhysicMaterial dryPhysicsMaterial;
    [SerializeField] private Material wetMaterial;
    [SerializeField] private Material dryMaterial;
    private MeshCollider meshCollider;
    private MeshRenderer meshRenderer;

    //Start is called before the first frame update
    void Start()
    {
        meshCollider = GetComponent<MeshCollider>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (isWet)
        {
            meshCollider.material = wetPhysicsMaterial;
            meshRenderer.material = wetMaterial;
        }
        else
        {
            meshCollider.material = dryPhysicsMaterial;
            meshRenderer.material = dryMaterial;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IsWater>() && !isWet)
        {
            meshCollider.material = wetPhysicsMaterial;
            meshRenderer.material = wetMaterial;
            isWet = true;
            Destroy(collision.gameObject);
        }
    }
}
