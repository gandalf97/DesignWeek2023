using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private GameObject waterDropPrefab;
    [SerializeField] private float force;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private float delay = 1;
    [SerializeField] private bool isOn = false;
    private float timer = 0;

    private void Update()
    {
        CreateWater();
    }

    void CreateWater()
    {
        if (!isOn)
            return;

        timer += Time.deltaTime;
        if (timer >= delay)
        {
            timer = 0;
            GameObject newDrop = Instantiate(waterDropPrefab, exitPoint.transform.position, exitPoint.transform.rotation);
            Vector3 direction = exitPoint.transform.position - transform.position;
            newDrop.GetComponent<Rigidbody>().AddForce(direction * force);
        }
    }
}
