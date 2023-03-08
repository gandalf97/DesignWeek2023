using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class PuddleScript : MonoBehaviour
{
    private SpriteRenderer texture;
    [SerializeField] private float growthScale;
    private float growthTimer = 0;

    private void Start()
    {
        texture = transform.root.gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        GrowPuddle();
    }

    private void GrowPuddle()
    {
        if(growthTimer > 0)
        {
            growthTimer -= Time.deltaTime;
            if (growthTimer < 0) growthTimer = 0;
            transform.localScale += new Vector3(Time.deltaTime * 0.1f, 0, Time.deltaTime * 0.1f);
            texture.size = new Vector2(transform.localScale.x * 2.73f, transform.localScale.z * 2.73f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IsWater>())
        {
            growthTimer += growthScale;
            Destroy(other.gameObject);
        }
    }
}
