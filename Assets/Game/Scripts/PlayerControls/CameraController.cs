using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 Offset;
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        transform.position = playerTransform.position + Offset;// Vector3.Lerp(transform.position, (playerTransform.position + Offset), Time.deltaTime * 10);
        //transform.LookAt(playerTransform);
    }
}
