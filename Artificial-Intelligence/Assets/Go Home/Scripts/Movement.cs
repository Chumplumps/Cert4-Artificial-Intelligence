using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//Character Movement
//This script requires the component Character controller
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Into PRG/RPG/Player/Player Movement")]
public class Movement : MonoBehaviour
{
    #region Variables
    [Header("PLAYER MOVEMENT")]
    [Space(10)]
    [Header("Characters Move Direction")]
    //vector3 called moveDirection
    public Vector3 moveDirection;
    //we will use this to apply movement in worldspace
    //private CharacterController (https://docs.unity3d.com/ScriptReference/CharacterController.html) charC
    private CharacterController _charC;
    [Header("Character Variables")]
    //public float variables jumpSpeed, speed, gravity
    public float jumpSpeed;
    public float speed, gravity;
    #endregion
    #region Start
    private void Start()
    {
        //charc is on this game object we need to get the character controller that is attached to it
        _charC = this.GetComponent<CharacterController>();
    }
    #endregion
    #region Update
    private void Update()
    {
        //if our character is grounded
        if (_charC.isGrounded)//we are able to move in game scene meaning
        {
            //moveDir has the value of Input.Get Axis.. Horizontal, 0, Vertical
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //moveDir is transformed in the direction of our moveDir
            moveDirection = transform.TransformDirection(moveDirection);
            //our moveDir is then multiplied by our speed
            moveDirection *= speed;

            //we can also jump if we are grounded so
            //in the input button for jump is pressed then
            if (Input.GetButton("Jump"))
            {
                //our moveDir.y is equal to our jump speed
                moveDirection.y = jumpSpeed;
            }
        }
        //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
        moveDirection.y -= gravity * Time.deltaTime;
        //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime
        _charC.Move(moveDirection * Time.deltaTime);
    }
    #endregion
}

//Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
//Input(https://docs.unity3d.com/ScriptReference/Input.html)








