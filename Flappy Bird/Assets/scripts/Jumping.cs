using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Vector3 gravity = new Vector3 (0f, -9.8f, 0f);
    private Vector3 direction;
    private Rigidbody2D rb;
    private float strength = 5f;


    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
        rb = GetComponent<Rigidbody2D>();
        direction = Vector3.zero;
    }

    void Update()
    {
        playerInputActions.Player.Jump.performed += Jump_performed;
        direction.y += gravity.y * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(obj.performed)
        {
            direction = Vector3.up * strength;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("score"))
        {
            GameManager.points += 1;
        }
        Debug.Log(collision.gameObject.tag);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        GameManager.instance.TryAgain();

    }


}
