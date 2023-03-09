using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour
{
    [SerializeField] private GameObject waterDropPrefab;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private float delay = 1;
    [SerializeField] private int amount = 5;

    private int numberDropped = 0;
    private float timer = 0;
    private bool spilled = false;

    private void Update()
    {
        CheckSpilled();
        Spill();
    }

    void CheckSpilled()
    {
        if (spilled) return;

        if (Vector3.Dot(transform.up, Vector3.up) < 0.7f)
        {
            spilled = true;
        }
    }

    void Spill()
    {
        if (spilled)
        {
            timer += Time.deltaTime;
            if (numberDropped < amount && timer >= delay)
            {
                Instantiate(waterDropPrefab, exitPoint.transform.position, exitPoint.transform.rotation);
                numberDropped++;
                timer = 0;
            }
        }

        if (numberDropped >= amount)
        { Destroy(this); }
    }
}
