using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;

    private Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start ()
    {
        // Get Children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        //Get referent to NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
    void Update ()
    {
   
        Patrol();

	}

    // () - Parenthesis
    // [] - Brackets
    // {} - Braces (Curly Braces, Curly Bois)

    void Patrol ()
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
}
