using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
public class NPCController : MonoBehaviour
{
    private NavMeshAgent navAgent;
    [SerializeField] private List<Transform> points = new List<Transform>();
    private int currentIndex = 0;
    private bool fellOver = false;
    private Rigidbody humanRB;

    // Start is called before the first frame update
    void Start()
    {
        humanRB = GetComponent<Rigidbody>();
        if (points.Count == 0)
            return;
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(points[currentIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (points.Count == 0 || fellOver)
            return;

        if (navAgent.remainingDistance < 0.1f)
        {
            currentIndex++;
            if (currentIndex >= points.Count) currentIndex = 0;

            navAgent.SetDestination(points[currentIndex].position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<GroundTile>() && !fellOver)
        {
            if (collision.gameObject.GetComponent<GroundTile>().isWet)
            {
                GetComponent<NavMeshAgent>().enabled = false;
                fellOver = true;
                humanRB.AddRelativeTorque(new Vector3(3,0,3), ForceMode.Impulse);
                //humanRB.AddForceAtPosition(new Vector3(1, 0, 1), this.transform.position - new Vector3(0, 0.5f, 0));
            }
        }
    }
}
