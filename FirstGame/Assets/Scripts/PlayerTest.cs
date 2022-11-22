using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    // Player movement tutorial

    //Vector2: (X,Y)
    //Vector3: (X,Y,Z)

    //Physical body

    [SerializeField]
    private float speed;

    private Rigidbody2D body;

    float horizontalMove = 0f;

    float vertMove = 0f;

    [SerializeField]
    float jumpForce = 0f;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
      

        body.velocity = new Vector2(horizontalMove * speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x,jumpForce);
        }

        Debug.Log(body.velocity);
    }


}
