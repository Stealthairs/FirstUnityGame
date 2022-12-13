using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    private float attackCooldown;

    public Animator anim;




    private string ATTACK_ANIMATION = "Attack";

    private string ENEMY_TAG = "Enemy";

 
    public Transform AttackPoint;
    public float AR = 0.5f;
    public LayerMask enemyLayers;
    
    


    private void Awake()
    {
        anim = GetComponent <Animator>();
  
   
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attack();
        }
  
    }

    


    private void attack()
    {
       
    

        anim.SetTrigger(ATTACK_ANIMATION);
        
        
      
      
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(AttackPoint.position, AR, enemyLayers);

        foreach(Collider2D enemy in hitEnemy)
        {
            Destroy(enemy.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, AR);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG)){

            Destroy(collision.gameObject);
            
            
        }
    }
    */

}
