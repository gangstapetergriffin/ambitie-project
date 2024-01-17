using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = 9.81f;
    public float verticalVelocity = 0.0f;
    public float jumpSpeed = 5.0f;
    public float moveSpeed = 10f;
    public float runningSpeed = 20f;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpSpeed;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }


        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveVector = transform.TransformDirection(moveVector);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveVector *= runningSpeed;
        }
        else
        {
            moveVector *= moveSpeed;
        }

        moveVector.y = verticalVelocity * 3;

        controller.Move(moveVector * Time.deltaTime);
    }
}
