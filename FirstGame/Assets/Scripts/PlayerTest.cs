using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    // Player movement tutorial

    //Vector2: (X,Y)
    //Vector3: (X,Y,Z)

    //speed of player
    [SerializeField]
    private float speed;

    //rigidbody componennt
    private Rigidbody2D body;

    //sprite component
    private SpriteRenderer sprite;

    //movement of player
    float horizontalMove = 0f;

    //force of player jump
    [SerializeField]
    float jumpForce = 0f;

    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private bool canJump = true;



    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    

    // Update is called once per frame
    void Update()
    {
        horizontalMovement();
        playerJump();
    }


    void playerJump()
    {
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && canJump)
        {
            canJump = false;
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
    }

    void horizontalMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (horizontalMove < 0)
        {
            sprite.flipX = true;
            body.velocity = new Vector2(horizontalMove * speed, body.velocity.y);
        }
        else if (horizontalMove > 0)
        {
            sprite.flipX = false;
            body.velocity = new Vector2(horizontalMove * speed, body.velocity.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }

    }



}
