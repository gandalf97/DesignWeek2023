using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] private GameObject signMesh;
    [SerializeField] private float accelerationValue = 10.0f;
    [SerializeField] private ForceMode movementForce;
    [SerializeField] private float maxVelocity = 50.0f;

    private bool input = false; //If player is sending input, for animations

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UserMovement();
        VelocityLimit();

        //Sign Animations
        signMesh.GetComponent<Animator>().SetBool("Walking", input);

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.GetComponent<GroundTile>())
        {
            if(collision.gameObject.GetComponent<GroundTile>().isWet)
            {
                playerRB.velocity += 0.07f * playerRB.velocity.normalized;
            }
            else
            {
                playerRB.velocity -= 0.07f * playerRB.velocity.normalized;
            }
        }
    }

    private void VelocityLimit()
    {
        if (playerRB.velocity.magnitude > maxVelocity)
        {
            playerRB.velocity.Normalize();
            playerRB.velocity *= maxVelocity;
        }
    }

    private void UserMovement()
    {

        input = false;

        Vector3 acceleration = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            acceleration.z += Time.deltaTime * accelerationValue;
            input = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            acceleration.z -= Time.deltaTime * accelerationValue;
            input = true;

        }
        if (Input.GetKey(KeyCode.D))
        {
            acceleration.x += Time.deltaTime * accelerationValue;
            input = true;

        }
        if (Input.GetKey(KeyCode.A))
        {
            acceleration.x -= Time.deltaTime * accelerationValue;
            input = true;

        }

        playerRB.velocity += acceleration;
    }


}
