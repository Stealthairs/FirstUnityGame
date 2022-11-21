using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstor : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform pos;
    //private Vector3 pos;

    [SerializeField]
    private float minX, maxX;

    //private bool flipX = false;




    [SerializeField]
    public float speed;

    private Rigidbody2D myBody;

    public SpriteRenderer sprite;






    private void Awake()
    {

    }



    void Start()
    {

        myBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        pos = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //myBody.velocity = new Vector2(speed, myBody.velocity.y);
        SwitchPosition();

        if (sprite.flipX == true)
        {
            transform.position -= new Vector3(2, 0f, 0f) * Time.deltaTime * 2;
        }
        else if(sprite.flipX == false)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        

    }


    private void SwitchPosition()
    {
        //pos = transform.position;
        //pos.x = transform.position.x
        


        if(pos.position.x > maxX)
        {
            sprite.flipX = true;
            
        }else if(pos.position.x < minX)
        {
    
            sprite.flipX = false;
        }


  
    }


    void AnimateMonstor()
    {

    }

}
