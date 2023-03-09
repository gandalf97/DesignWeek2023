using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] private float movementValue = 1.0f;
    [SerializeField] private Animator signAnimator;
    [SerializeField] private float accelerationValue = 10.0f;
    [SerializeField] private ForceMode movementForce;
    [SerializeField] private float waterSlipMultplier = 0.5f;
    [SerializeField] private Transform cameraTransform;
    private bool inWater = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UserMovement();
        PlayerRotation();

        //Sign Animations
        PlayWalkAnimation();
    }

    private void PlayWalkAnimation()
    {
        if(inWater)
        {
            signAnimator.SetFloat("PlayerSpeed", 0.0f);
            return;
        }

        signAnimator.SetFloat("PlayerSpeed", playerRB.velocity.magnitude / 13.0f);
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

        moveDirection = cameraTransform.rotation * moveDirection;
        moveDirection.y = 0;
        moveDirection.Normalize();
        moveDirection *= movementValue;
        playerRB.AddForce(moveDirection, movementForce);

        if (inWater)
        {
            playerRB.velocity += playerRB.velocity.normalized * waterSlipMultplier;
        }
    }

    private void PlayerRotation()
    {
        if (playerRB.velocity.sqrMagnitude > 0)
        {
            transform.LookAt(transform.position + playerRB.velocity - new Vector3(0, playerRB.velocity.y, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PuddleScript>())
        {
            inWater = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PuddleScript>())
        {
            inWater = false;
        }
    }
}
