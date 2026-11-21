using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class NefraJump : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 7f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private bool jumpRequested;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        if (!jumpRequested)
        {
            return;
        }

        jumpRequested = false;

        if (body.velocity.y <= 0f && body.IsTouchingLayers(groundLayer))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }
}