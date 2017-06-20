using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    enum STATE
    {
        None = 0,
        Walk = 1,
        Jump = 2,
        Jump2 = 3,
    }
    CharacterController characterController;
    public Transform cameraTransform;
    public float moveSpeed = 10.0f;

    public float jumpSpeed = 10.0f;
    public float gravity = -20.0f;

    float yVelocity = 0.0f;

    Vector3 latestVector;

    STATE state;

    float dx;
    float dz;

	// Use this for initialization
	void Start ()
    {
        characterController = GetComponent<CharacterController>();
        latestVector = new Vector3(0.0f, 0.0f, 0.0f);
        state = STATE.None;
        dx = 0.0f;
        dz = 0.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        dx = Input.GetAxis("Horizontal");
        dz = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(dx, 0, dz);
       
        moveDirection = cameraTransform.TransformDirection(moveDirection);

        if(dz != 0.0f && dz != 0.0f)
        {
            if (moveDirection.x == 0.0f && moveDirection.x == 0.0f)
            {
                moveDirection = latestVector;
            }
            else
            {
                latestVector = moveDirection;
            }
        }



        moveDirection *= moveSpeed;

        if (characterController.isGrounded == true)
        {
            yVelocity = 0.0f;
            if(state == STATE.Jump || state == STATE.Jump2)
            {
                state = STATE.None;
            }
            
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (state == STATE.None)
            {
                yVelocity = jumpSpeed;
                state = STATE.Jump;
            }
            else if (state == STATE.Jump)
            {
                yVelocity = jumpSpeed;
                state = STATE.Jump2;
            }

        }



        yVelocity += (gravity * Time.deltaTime);
        moveDirection.y = yVelocity;

        characterController.Move(moveDirection * Time.deltaTime);
	}
}
