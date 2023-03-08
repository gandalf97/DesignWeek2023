using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(MeshRenderer))]
public class GroundTile : MonoBehaviour
{
    public bool isWet;
    [SerializeField] private PhysicMaterial wetPhysicsMaterial;
    [SerializeField] private PhysicMaterial dryPhysicsMaterial;
    [SerializeField] private Material wetMaterial;
    [SerializeField] private Material dryMaterial;
    private BoxCollider boxCollider;
    private MeshRenderer meshRenderer;

    //Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();

        if (isWet)
        {
            boxCollider.material = wetPhysicsMaterial;
            meshRenderer.material = wetMaterial;
        }
        else
        {
            boxCollider.material = dryPhysicsMaterial;
            meshRenderer.material = dryMaterial;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.GetComponent<IsWater>() && !isWet)
        //{
        //    boxCollider.material = wetPhysicsMaterial;
        //    meshRenderer.material = wetMaterial;
        //    isWet = true;
        //    Destroy(collision.gameObject);
        //}
    }
}
