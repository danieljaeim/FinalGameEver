using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    //Create variable for player input component.
    private PlayerInput playerInput;

    //create variable for player rigidbody.
    private Rigidbody2D rb;

    //Create variable for move direction.
    Vector2 moveDirection;
    Vector2 movement;
    private InputAction moveAction;
    public float moveSpeed = 20;
    private float moveX;
    private float moveY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];

        print(moveDirection);
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
        moveX = moveDirection.x;
        moveY = moveDirection.y;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * moveSpeed, moveY);
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveX = moveDirection.x;
        moveY = moveDirection.y;
    }
}
