using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _gravity = -9.8f;

    private CharacterController _controller;
    private float _velocity;
    private Vector3 _moveDirection;



    private void Awake() {
        _controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate() {
        Move(_moveDirection);
        dnGravity();
    }
    private void Update() {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
    }

    private void Move(Vector3 direction){
        _controller.Move(direction * _speed * Time.fixedDeltaTime);
    }

    private void dnGravity(){

        _velocity += _gravity * Time.fixedDeltaTime;
        _controller.Move(Vector3.down * _velocity * Time.fixedDeltaTime);

    }

}
