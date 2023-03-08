using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] private float movementValue = 1.0f;
    [SerializeField] private ForceMode movementForce;

    [SerializeField] private float waterSlipMultplier = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UserMovement();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<PuddleScript>())
        {
            playerRB.velocity += playerRB.velocity.normalized * waterSlipMultplier;
        }
    }

    private void UserMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1;
        }

        moveDirection.Normalize();
        moveDirection *= movementValue;
        playerRB.AddForce(moveDirection, movementForce);
    }
}
