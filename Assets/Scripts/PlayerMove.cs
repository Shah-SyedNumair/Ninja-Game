using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController control;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.5f;

    public Transform GroundCheck;
    public float groundFar = 0.4f;
    public LayerMask groundMask;
    public bool DoubleJump = true;

    public Vector3 move;
    public float dashSpeed;
    public float dashTime;
    private const float DoublePressTime = 0.5f;
    private float lastPressedTime;

    public float SprintSpeed;
    public bool isSprint = false;

    public bool isCrouch = false;
    public float croachmulti;
    public float crouchheigth;
    public float standheigth;

    Vector3 velocity;
    bool isGround;

    // Update is called once per frame
    void Update()
    {

        isGround = Physics.CheckSphere(GroundCheck.position, groundFar, groundMask);

        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //crouch
        if (Input.GetKey(KeyCode.C))
        {
            isCrouch = true;
            control.height = crouchheigth;
        }
        else
        {
            isCrouch = false;
            control.height = standheigth;
        }

        //main movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        //jump
        if (Input.GetButtonDown("Jump") && isGround)
        {
            DoubleJump = true;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (isCrouch)
        {
            velocity.y += gravity * 1.75f * Time.deltaTime;
        }
        else if (!isGround & DoubleJump & Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            DoubleJump = false;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        control.Move(velocity * Time.deltaTime);

        //dash and sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            float timeSinceLastPress = Time.time - lastPressedTime;
            if((timeSinceLastPress <= DoublePressTime) && PlayerStamina.instance.CheckEnoughStamina(10))
            {
                PlayerStamina.instance.UseStamina(10);
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    move = transform.right * x;
                    StartCoroutine(Dash());
                }
                else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    move = transform.forward * z;
                    StartCoroutine(Dash());
                }
            }
            lastPressedTime = Time.time;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprint = true;
        }
        else
        {
            isSprint = false;
        }

        if (isCrouch)
        {
            control.Move(move * speed * croachmulti * Time.deltaTime);
        }
        else if (isSprint)
        {
            control.Move(move * speed * SprintSpeed * Time.deltaTime);
        }
        else
        {
            control.Move(move * speed * Time.deltaTime);
        }

    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            control.Move(move * dashSpeed * Time.deltaTime);

            yield return null;
        }
    }


}
