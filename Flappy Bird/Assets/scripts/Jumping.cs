using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Vector3 gravity = new Vector3 (0f, -5f, 0f);
    private Vector3 upwardForce = new Vector3(0f, 100f, 0f);
    private Rigidbody2D rb;
    private bool pressed = false;


    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(gravity * Time.deltaTime);
        playerInputActions.Player.Jump.performed += Jump_performed;

    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(obj.performed)
        {
            transform.Translate((upwardForce-gravity) * Time.deltaTime);
        }
    }
}
