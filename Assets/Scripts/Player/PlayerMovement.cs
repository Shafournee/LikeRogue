using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidBody;

    enum moveDir { up, down, left, right, none }

    moveDir uddirection;

    moveDir lrdirection;

    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
            Debug.Log("Player lacks a rigid body!");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            uddirection = moveDir.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            uddirection = moveDir.down;
        }
        else
        {
            uddirection = moveDir.none;
        }

        if (Input.GetKey(KeyCode.A))
        {
            lrdirection = moveDir.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            lrdirection = moveDir.right;
        }
        else
        {
            lrdirection = moveDir.none;
        }
    }

    private void FixedUpdate()
    {
        if (uddirection == moveDir.up)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.normalized.x, 1f) * speed;
        }
        else if (uddirection == moveDir.down)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.normalized.x, -1f) * speed;
        }
        else
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.normalized.x, 0f) * speed;
        }

        if (lrdirection == moveDir.right)
        {
            rigidBody.velocity = new Vector2(1f, rigidBody.velocity.normalized.y) * speed;
        }
        else if (lrdirection == moveDir.left)
        {
            rigidBody.velocity = new Vector2(-1f, rigidBody.velocity.normalized.y) * speed;
        }
        else
        {
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.normalized.y) * speed;
        }
    }
}
