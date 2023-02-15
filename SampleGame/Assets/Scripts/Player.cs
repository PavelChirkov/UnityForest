using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private VariableJoystick variableJoystick;
    private GameObject playerBody;
    private Animator animator;


    private CharacterController controller;
    private float velocity;
    private Vector3 moveDirection;
  

    private void Start()
    {
            playerBody = GameObject.FindGameObjectWithTag("PlayerBody");
            animator = playerBody.GetComponent<Animator>();
    }

    private void Awake() {
        controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate() {
        Move(moveDirection); 
        dnGravity();
    }
    private void Update() {
        /*_moveDirection = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));*/
        moveDirection = new Vector3(variableJoystick.Horizontal, 0f, variableJoystick.Vertical);

        if (moveDirection != Vector3.zero)
        {
            
            animator.Play("running");
             gameObject.transform.forward = moveDirection;
        }
        else
        {
            /*animator.SetBool("idle", false);*/
        }
    }

    private void Move(Vector3 direction){

        controller.Move(direction * speed * Time.fixedDeltaTime);
       

    }

    private void dnGravity(){

        velocity += gravity * Time.fixedDeltaTime;
        controller.Move(Vector3.up * velocity * Time.fixedDeltaTime);

    }

}
