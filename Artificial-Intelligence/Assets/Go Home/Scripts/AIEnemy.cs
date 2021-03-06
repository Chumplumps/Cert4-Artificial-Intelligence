﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


  //Controller script for enemy


public class AIEnemy : MonoBehaviour
{

    public Transform target;

    private NavMeshAgent agent; // Reference to the NavMeshAgent component

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Update destination of NavMeshAgent
        agent.SetDestination(target.position);
	}
}
