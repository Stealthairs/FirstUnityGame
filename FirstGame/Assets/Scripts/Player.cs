using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    
    public Rigidbody2D myBody;

    private Animator anim;

    private SpriteRenderer sr;

    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    


    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }




    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeys();
        AnimatePlayer();
        PlayerJump();
     

    }

    private void FixedUpdate(){
        PlayerJump();
    }

    void PlayerMoveKeys(){
        movementX = Input.GetAxisRaw("Horizontal");
        //-1, 1, 1
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    //play moves
    void AnimatePlayer(){

        if(movementX < 0){
            //left
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
    

        }else if(movementX > 0){
            //right
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;

        }else{
            //idle
            anim.SetBool(WALK_ANIMATION, false);
        }

    }

    // players jumps using space bar
    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
        
    
    }

    //detects collisions
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            
        }
    }




}
