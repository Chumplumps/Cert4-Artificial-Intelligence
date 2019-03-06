using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Seek
    }
    public State currentState;
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;

    private Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    private Transform target;
    void Start()
    {
        // Get Children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        //Get referent to NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        currentState = State.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Seek:
                Seek();
                break;
            default:
                Patrol();
                break;
        }
    }

    // () - Parenthesis
    // [] - Brackets
    // {} - Braces (Curly Braces, Curly Bois)

    void Patrol()
    {
        // 1 - Get the current waypoint
        Transform point = waypoints[currentIndex];
        // 2 - Get distance to waypoint
        float distance = Vector3.Distance(transform.position, point.position);
        // 3 - If distance < stopping distance
        if (distance < stoppingDistance)
        {
            //      4 - Switch to next waypoint
            currentIndex++; // currentIndex = currentIndex + 1
            // 4.1 - If the current index exceeds array size
            if (currentIndex >= waypoints.Length)
            {
                //      4.2 - Reset current index back to 1
                currentIndex = 1;
            }
        }
        // 5 - Translate enemy to waypoint
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);

        // 5 - Tell NavMeshAgent it's destination
        agent.SetDestination(point.position);
    }
    public void Seek()
    { //Get enemy to follow target
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Set target to the thing that we hit
            target = other.transform;
            //Switch state over to Seek
            currentState = State.Seek;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Switch state back over to Patrol
            currentState = State.Patrol;
        }
    }
}
