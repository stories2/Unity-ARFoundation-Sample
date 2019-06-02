using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;

    private Vector3 moveDirection;

    void Update()
    {
        // Vector3 test = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        // // Debug.Log("test: " + test);
        // moveDirection = test;
    }

    public void SetMoveDirection(Vector3 moveDirection) {
        this.moveDirection = moveDirection;
        // Debug.Log("Set movement: " + moveDirection);
    }

    void FixedUpdate()
    {
        // Debug.Log("Fixed movement: " + moveDirection);
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }
}
