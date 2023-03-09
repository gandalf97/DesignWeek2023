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

        UpdateDestination();
        Rotation();
    }

    private void UpdateDestination()
    {
        if (navAgent.remainingDistance < 0.1f)
        {
            currentIndex++;
            if (currentIndex >= points.Count) currentIndex = 0;

            navAgent.SetDestination(points[currentIndex].position);
        }
    }

    private void Rotation()
    {
        if (navAgent.velocity.sqrMagnitude > 0)
        {
            transform.LookAt(transform.position + navAgent.velocity - new Vector3(0, navAgent.velocity.y, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PuddleScript>() && !fellOver)
        {
            Vector3 forceDirection = navAgent.velocity;
            navAgent.enabled = false;
            fellOver = true;
            humanRB.isKinematic = false;
            humanRB.AddForceAtPosition(forceDirection * 100.0f, this.transform.position - new Vector3(0, 2.0f, 0));
        }
    }
}
