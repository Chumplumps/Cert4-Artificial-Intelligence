using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MAKE SURE THIS HAS RIGIDBODY
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 20f;
    private Rigidbody rigid;
	void Start ()
    {
        //Get reference to rigidbody
        rigid = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        // Get Input Axis as float for x and y
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        // Create Input vector
        Vector3 input = new Vector3(inputX, 0, inputZ);
        // Apply velocity
        rigid.velocity = input * movementSpeed;
	}
}
