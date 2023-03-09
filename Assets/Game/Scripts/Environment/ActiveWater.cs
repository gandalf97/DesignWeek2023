using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActiveWater : MonoBehaviour
{
    [SerializeField] private GameObject waterDropPrefab;
    [SerializeField] private float force;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private float delay = 1;
    [SerializeField] private bool isOn = false;
    [SerializeField] private float duration = 5;
    private float timer = 0;
    private float lifeTimer = 0;

    [SerializeField] private TMP_Text message;
    [SerializeField] private string messageText;

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
            GameObject newDrop = Instantiate(waterDropPrefab, transform.root);
            newDrop.transform.position = exitPoint.position;
            Vector3 direction = exitPoint.transform.position - transform.position;
            newDrop.GetComponent<Rigidbody>().AddForce(direction * force);
        }

        lifeTimer += Time.deltaTime;
        if(lifeTimer >= duration)
        {
            Destroy(this);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            message.text = "Press E to " + messageText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            message.text = "";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOn)
        {
            isOn = true;
            message.text = "";
        }
    }
}
