using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox_Controller : MonoBehaviour
{
    public CharacterController2D Character;
    public Animator animator;

    float horizontalValue = 0f;
    [SerializeField] float runSpeed = 40f;

    bool jump = false;
    bool crouch = false;


    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalValue));

        //Enable Jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);

        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        Character.Move(horizontalValue * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
