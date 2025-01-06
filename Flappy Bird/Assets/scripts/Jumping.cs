using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Vector3 gravity = new Vector3 (0f, -9.8f, 0f);
    private Vector3 upwardForce = new Vector3(0f, 20f, 0f);
    private Rigidbody2D rb;


    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += gravity * Time.deltaTime;

        if (playerInputActions.Player.Jump.IsPressed())
        {
            rb.AddForce(upwardForce * Time.deltaTime);
        }
    }
}
