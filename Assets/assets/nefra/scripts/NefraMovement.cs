using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NefraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Animator _Nefra;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D body;
    private float horizontalInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

   private void Update()
{
    horizontalInput = Input.GetAxisRaw("Horizontal");
    bool isWalking = horizontalInput != 0f;

    if (_Nefra != null)
    {
        _Nefra.SetBool("IsWalking", isWalking);
    }

    if (spriteRenderer != null && isWalking)
    {
        spriteRenderer.flipX = horizontalInput < 0f;
    }
}
    private void FixedUpdate()
    {
        body.velocity = new Vector2(
            horizontalInput * moveSpeed,
            body.velocity.y
        );
    }
}